using Helix.LBSService.EventConsumer.Models;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Diagnostics;
using System.Text;

namespace Helix.LBSService.EventConsumer.ProductTransaction
{
	public class OutCountingTransactionConsumer : IDisposable
	{
		private readonly ILG_OutCountingTransactionService _outCountingTransactionService;
		private readonly ConnectionFactory _factory;
		private readonly IModel _channel;
		private readonly HttpClient _httpClient;

		private string _queueName = "ProductService.OutCountingTransactionIns"; //gonna change
		private string _exchange = "HelixTopicName";

		public OutCountingTransactionConsumer(ILG_OutCountingTransactionService outCountingTransactionService, HttpClient httpClient)
		{
			_outCountingTransactionService = outCountingTransactionService;


			_factory = new ConnectionFactory
			{
				Uri = new Uri(ApplicationParameter.RabbitMQAdress)
			};

			var connection = _factory.CreateConnection();
			_channel = connection.CreateModel();
			_channel.ExchangeDeclare(exchange: _exchange, type: "direct");
			_channel.QueueBind(_queueName, exchange: _exchange, routingKey: _queueName);
			_httpClient = httpClient;
		}

		public async Task ProcessMessagesAsync()
		{
			await Task.Run(GetMessageFromQueue);
		}
		private async Task<bool> PostDtoToApiAsync(OutCountingTransactionDto dto)
		{
			try
			{
				string apiUrl = ApplicationParameter.ApiAdress; // Replace with your actual API endpoint

				string jsonDto = JsonConvert.SerializeObject(dto);

				StringContent content = new StringContent($"{jsonDto}/api/WorkOrder/Insert", Encoding.UTF8, "application/json");

				HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

				if (response.IsSuccessStatusCode)
				{
					Log.Information($" [>] Successfully posted DTO to API.");
					return true;
				}
				else
				{
					Log.Error($" [!] Failed to post DTO to API. Status code: {response.StatusCode}");
					return false;
				}
			}
			catch (HttpRequestException ex)
			{
				Log.Error($"Error in PostDtoToApiAsync: {ex.Message}");
				return false;
			}
			catch (JsonException ex)
			{
				Log.Error($"Error in PostDtoToApiAsync: {ex.Message}");
				return false;
			}
			catch (Exception ex)
			{
				Log.Error($"Error in PostDtoToApiAsync: {ex.Message}");
				return false;
			}
		}

		private void GetMessageFromQueue()
		{
			try
			{
				Log.Information($" [*] {_queueName} Waiting for messages.");

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
						Log.Information($" [x] Received {message}");
						dto = JsonConvert.DeserializeObject<OutCountingTransactionDto>(message);

						bool result = await PostDtoToApiAsync(dto);

						if (result)
						{
							_channel.BasicAck(ea.DeliveryTag, false);
							Log.Information($" [x] Acknowledged message: {message}");
						}
						else
						{
							_channel.BasicReject(ea.DeliveryTag, false);
							Log.Error($" [!] Message processing failed: Unable to post DTO to API");
							Log.Error($" [!] Message negatively acknowledged and requeued: {message}");
						}
					}
					catch (Exception ex)
					{
						Log.Error($"Error processing message: {ex.Message}");
						_channel.BasicReject(ea.DeliveryTag, false);
						Log.Error($" [!] Message negatively acknowledged and requeued due to an error.");
					}
				};

				// Add a mechanism for graceful shutdown if needed
			}
			catch (Exception ex)
			{
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
