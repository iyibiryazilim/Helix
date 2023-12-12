using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Helix.EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : BaseEventBus
    {
        RabbitMQPersistentConnection persistentConnection;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IModel _consumerChannel;

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
                _connectionFactory = new ConnectionFactory();
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
                var consumer = new EventingBasicConsumer(_consumerChannel);

                consumer.Received += Consumer_Received;

                _consumerChannel.BasicConsume(queue: GetSubName(eventName),
                                                                    autoAck: false,
                                                                    consumer: consumer);
            }

        }

        private async void Consumer_Received(object sender, BasicDeliverEventArgs args)
        {
            var eventName = args.RoutingKey;
            eventName = ProcessEventName(eventName);
            var message = Encoding.UTF8.GetString(args.Body.Span);

            try
            {
                await ProcessEvent(eventName, message);
            }
            catch (Exception)
            {

                throw;
            }

            _consumerChannel.BasicAck(args.DeliveryTag, multiple: false);

        }

        public override void Publish(IntegrationEvent @event)
        {
            if (!persistentConnection.IsConnection)
                persistentConnection.TryConnect();

            var policy = Policy.Handle<SocketException>()
                                      .Or<BrokerUnreachableException>()
                                      .WaitAndRetry(_eventBusconfig.ConnectionRetryCount, retyAttemp => TimeSpan.FromSeconds(Math.Pow(2, retyAttemp)),(ex, time) =>
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
            StartBasicConsume(eventName);
        }

        public override void UnSubscribe<T, TH>()
        {
            _subscriptionManager.RemoveSubscription<T, TH>();
        }
    }
}
