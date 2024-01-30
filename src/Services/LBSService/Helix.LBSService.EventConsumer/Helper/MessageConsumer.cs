using Helix.LBSService.EventConsumer.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;

namespace Helix.LBSService.EventConsumer.Helper
{
	public class MessageConsumer<TDto> : IDisposable
	{
		private readonly IService<TDto> _service;
		private readonly ConnectionFactory _factory;
		private readonly IModel _channel;
		private readonly HttpClient _httpClient;

		private readonly string _queueName;
		private readonly string _exchange;

		public MessageConsumer(IService<TDto> service, string queueName, string exchange, HttpClient httpClient)
		{
			_service = service;
			_httpClient = httpClient;
			_queueName = queueName;
			_exchange = exchange;

			_factory = new ConnectionFactory
			{
				Uri = new Uri(ApplicationParameter.RabbitMQAdress)
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

		private async Task<bool> PostDtoToApiAsync(TDto dto, string apiEndpoint)
		{
			try
			{
				string apiUrl = ApplicationParameter.ApiAdress; // Replace with your actual API endpoint

				string jsonDto = JsonConvert.SerializeObject(dto);

				StringContent content = new StringContent(jsonDto, Encoding.UTF8, "application/json");

				HttpResponseMessage response = await _httpClient.PostAsync(apiUrl + apiEndpoint, content);

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
				TDto dto = Activator.CreateInstance<TDto>();

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
						dto = JsonConvert.DeserializeObject<TDto>(message);

						bool result = await PostDtoToApiAsync(dto, _service.GetApiEndpoint());

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
