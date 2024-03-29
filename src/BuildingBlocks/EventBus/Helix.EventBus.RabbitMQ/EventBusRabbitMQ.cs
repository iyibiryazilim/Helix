﻿using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Net.Sockets;
using System.Text;

namespace Helix.EventBus.RabbitMQ
{
	public class EventBusRabbitMQ : BaseEventBus
	{
		private RabbitMQPersistentConnection persistentConnection;
		private readonly IConnectionFactory _connectionFactory;
		private readonly IModel _consumerChannel;
		private EventingBasicConsumer _consumer;

		public EventBusRabbitMQ(IServiceProvider serviceProvider, EventBusConfig eventBusconfig) : base(serviceProvider, eventBusconfig)
		{
			if (eventBusconfig.Connection != null)
			{
				var configJson = JsonConvert.SerializeObject(eventBusconfig.Connection, new JsonSerializerSettings
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				});

				_connectionFactory = JsonConvert.DeserializeObject<ConnectionFactory>(configJson);
			}
			else
			{
				_connectionFactory = new ConnectionFactory()
				{
					Uri = eventBusconfig.EventBusConnectionString == string.Empty ? new Uri("amqps://oqhbtvgt:Zh4cCLQdL1U3_E5dtAA0TOh7vnYUVA7g@rattlesnake.rmq.cloudamqp.com/oqhbtvgt") : new Uri(eventBusconfig.EventBusConnectionString)
					//HostName = "rattlesnake-01.rmq.cloudamqp.com",
					//Port = 5672,
					//UserName = "oqhbtvgt",
					//Password = "Zh4cCLQdL1U3_E5dtAA0TOh7vnYUVA7g"
				};
			}

			persistentConnection = new RabbitMQPersistentConnection(_connectionFactory, eventBusconfig.ConnectionRetryCount);

			_consumerChannel = CreateConsumerModel();

			_subscriptionManager.OnEventRemoved += SubscriptionManager_OnEventRemoved;
		}

		private void SubscriptionManager_OnEventRemoved(object? sender, string eventName)
		{
			eventName = ProcessEventName(eventName);

			if (!persistentConnection.IsConnection)
				persistentConnection.TryConnect();

			_consumerChannel.QueueUnbind(queue: eventName,
														 exchange: _eventBusconfig.DefaultTopicName,
														 routingKey: eventName
															);

			if (_subscriptionManager.isEmpty)
				_consumerChannel.Close();
		}

		private IModel CreateConsumerModel()
		{
			if (!persistentConnection.IsConnection)
				persistentConnection.TryConnect();

			var channel = persistentConnection.CreateModel();

			channel.ExchangeDeclare(exchange: _eventBusconfig.DefaultTopicName, type: "direct");

			return channel;
		}

		private void StartBasicConsume(string eventName)
		{
			if (_consumerChannel != null)
			{
				try
				{
					_consumerChannel.QueueDeclare(queue: GetSubName(eventName),
																  durable: true,
																  exclusive: false,
																  autoDelete: false,
																  arguments: null);

					_consumerChannel.QueueBind(queue: $"{_eventBusconfig.SubscriperClientAppName}.{eventName}", exchange: _eventBusconfig.DefaultTopicName, routingKey: $"{_eventBusconfig.SubscriperClientAppName}.{eventName}");
					_consumer = new EventingBasicConsumer(_consumerChannel);
					_consumer.Received += Consumer_Received;

					_consumerChannel.BasicConsume(queue: GetSubName(eventName),
																		autoAck: false,
																		consumer: _consumer);
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		private async void Consumer_Received(object sender, BasicDeliverEventArgs args)
		{
			var eventName = args.RoutingKey;
			eventName = ProcessEventName(eventName);
			var message = Encoding.UTF8.GetString(args.Body.Span);

			if (await ProcessEvent(eventName, message))
			{
				_consumerChannel.BasicAck(args.DeliveryTag, multiple: false);
			}
			else
			{
				bool requeue = true;
				_consumerChannel.BasicNack(args.DeliveryTag, multiple: false, requeue: requeue);
			}
			// Acknowledge the message if ProcessEvent succeeds
		}

		public override void Publish(IntegrationEvent @event)
		{
			if (!persistentConnection.IsConnection)
				persistentConnection.TryConnect();

			var policy = Policy.Handle<SocketException>()
									  .Or<BrokerUnreachableException>()
									  .WaitAndRetry(_eventBusconfig.ConnectionRetryCount, retyAttemp => TimeSpan.FromSeconds(Math.Pow(2, retyAttemp)), (ex, time) =>
									  {
										  //create log
									  });

			var eventName = @event.GetType().Name;
			eventName = ProcessEventName(eventName);

			_consumerChannel.ExchangeDeclare(exchange: _eventBusconfig.DefaultTopicName,
																  type: "direct");

			var message = JsonConvert.SerializeObject(@event);
			var body = Encoding.UTF8.GetBytes(message);

			policy.Execute(() =>
			{
				var properties = _consumerChannel.CreateBasicProperties();
				properties.DeliveryMode = 2; //persistent

				_consumerChannel.QueueDeclare(queue: GetSubName(eventName),
																  durable: true,
																  exclusive: false,
																  autoDelete: false,
																  arguments: null);

				_consumerChannel.BasicPublish(exchange: _eventBusconfig.DefaultTopicName,
															   routingKey: eventName,
															   mandatory: true,
															   basicProperties: properties,
															   body: body);
			});
		}

		public override void Subscribe<T, TH>()
		{
			var eventName = typeof(T).Name;
			eventName = ProcessEventName(eventName);

			if (!_subscriptionManager.HasSubscriptionsForEvent(eventName))
			{
				_consumerChannel.QueueDeclare(queue: GetSubName(eventName),
																  durable: true,
																  exclusive: false,
																  autoDelete: false,
																  arguments: null);

				_consumerChannel.QueueBind(queue: GetSubName(eventName),
															  exchange: _eventBusconfig.DefaultTopicName,
															  routingKey: eventName);
			}

			_subscriptionManager.AddSubscription<T, TH>();
			//StartBasicConsume(eventName);
		}

		public override void UnSubscribe<T, TH>()
		{
			_subscriptionManager.RemoveSubscription<T, TH>();
		}

		public override void Consume(IntegrationEvent @event)
		{
			try
			{
				var eventName = @event.GetType().Name;
				// Check if eventName ends with the suffix
				if (eventName.EndsWith(_eventBusconfig.EventNameSuffix))
				{
					// Remove the suffix
					eventName = eventName.Substring(0, eventName.Length - _eventBusconfig.EventNameSuffix.Length);
				}
				StartBasicConsume(eventName);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public override EventingBasicConsumer GetConsumer()
		{
			return _consumer;
		}

		public override IModel GetConsumerChannel()
		{
			return _consumerChannel;
		}
	}
}