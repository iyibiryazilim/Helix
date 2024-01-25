using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;

namespace Helix.LBSService.EventConsumer.ProductTransaction
{
	public class OutCountingTransactionConsumer : IDisposable
	{
		private readonly ILG_OutCountingTransactionService _outCountingTransactionService;
		private readonly ConnectionFactory _factory;
		private readonly IModel _channel;

		private string _queueName = ""; //gonna change
		private string _exchange = "HelixTopicName";

		public OutCountingTransactionConsumer(ILG_OutCountingTransactionService outCountingTransactionService)
		{
			_outCountingTransactionService = outCountingTransactionService;

			_factory = new ConnectionFactory
			{
				Uri = new Uri("amqps://oqhbtvgt:Zh4cCLQdL1U3_E5dtAA0TOh7vnYUVA7g@rattlesnake.rmq.cloudamqp.com/oqhbtvgt")
			};

			var connection = _factory.CreateConnection();
			_channel = connection.CreateModel();
			_channel.ExchangeDeclare(exchange: _exchange, type: "direct");
			_channel.QueueBind(_queueName, exchange: _exchange, routingKey: _queueName);
		}

		public async Task ProcessMessagesAsync()
		{
			await Task.Run(GetMessageFromQueue);
		}

		private void GetMessageFromQueue()
		{
			try
			{
				Console.WriteLine(" [*] Waiting for messages.");

				var consumer = new EventingBasicConsumer(_channel);
				OutCountingTransactionDto dto = new OutCountingTransactionDto();

				_channel.BasicConsume(
					queue: _queueName,
					autoAck: false,
					consumer: consumer
				);

				consumer.Received += async (model, ea) =>
				{
					try
					{
						var body = ea.Body.ToArray();
						var message = Encoding.UTF8.GetString(body);
						Console.WriteLine($" [x] Received {message}");
						dto = JsonConvert.DeserializeObject<OutCountingTransactionDto>(message);

						var result = await _outCountingTransactionService.Insert(dto);

						if (result.IsSuccess)
						{
							_channel.BasicAck(ea.DeliveryTag, false);
							Console.WriteLine($" [x] Acknowledged message: {message}");
						}
						else
						{
							Console.WriteLine($" [!] Message processing failed: {result.Message}");

							// Optionally, negatively acknowledge the message and request requeue
							_channel.BasicReject(ea.DeliveryTag, false);
							Console.WriteLine($" [!] Message negatively acknowledged and requeued: {message}");
						}

					}
					catch (Exception ex)
					{
						// Handle specific exceptions or log the error
						Console.WriteLine($"Error processing message: {ex.Message}");

						// Optionally, negatively acknowledge the message and request requeue
						_channel.BasicNack(ea.DeliveryTag, false, true);
						Console.WriteLine($" [!] Message negatively acknowledged and requeued due to an error.");
					}
				};

				// Add a mechanism for graceful shutdown if needed

			}
			catch (Exception ex)
			{
				// Handle specific exceptions or log the error
				Console.WriteLine($"Error in GetMessageFromQueue: {ex.Message}");
			}
		}

		public void Dispose()
		{
			if (_channel.IsOpen)
				_channel.Close();

		}
	}
}
