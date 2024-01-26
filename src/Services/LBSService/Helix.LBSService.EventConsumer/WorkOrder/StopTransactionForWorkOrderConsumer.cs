using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Diagnostics;
using System.Text;

namespace Helix.LBSService.EventConsumer.WorkOrder
{
	public class StopTransactionForWorkOrderConsumer : IDisposable
	{
		private readonly ILG_WorkOrderService _workOrderService;
		private readonly ConnectionFactory _factory;
		private readonly IModel _channel;
		private string _queueName = "ProductionService.StopTransactionForWorkOrderInserted";
		private string _exchange = "HelixTopicName";
		public StopTransactionForWorkOrderConsumer(ILG_WorkOrderService workOrderService)
		{
			_workOrderService = workOrderService;

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
				Log.Information($" [*] {_queueName} Waiting for messages.");

				var consumer = new EventingBasicConsumer(_channel);
				StopTransactionForWorkOrderDto dto = new StopTransactionForWorkOrderDto();

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
						Log.Information($" [x] Received {message}");
						dto = JsonConvert.DeserializeObject<StopTransactionForWorkOrderDto>(message);

						var result = await _workOrderService.InsertStopTransaction(dto);

						if (result.IsSuccess)
						{
							_channel.BasicAck(ea.DeliveryTag, false);
							Log.Information($" [x] Acknowledged message: {message}");
						}
						else
						{
							Log.Error($" [!] Message processing failed: {result.Message}");

							// Optionally, negatively acknowledge the message and request requeue
							_channel.BasicReject(ea.DeliveryTag, false);
							Log.Error($" [!] Message negatively acknowledged and requeued: {message}");
						}

					}
					catch (Exception ex)
					{
						// Handle specific exceptions or log the error
						Log.Error($"Error processing message: {ex.Message}");

						// Optionally, negatively acknowledge the message and request requeue
						_channel.BasicReject(ea.DeliveryTag, false);
						Log.Error($" [!] Message negatively acknowledged and requeued due to an error.");
					}
				};

				// Add a mechanism for graceful shutdown if needed

			}
			catch (Exception ex)
			{
				// Handle specific exceptions or log the error
				Log.Error($"Error in GetMessageFromQueue: {ex.Message}");
			}
		}

		public void Dispose()
		{
			if (_channel.IsOpen)
				_channel.Close();

		}
	}
}
