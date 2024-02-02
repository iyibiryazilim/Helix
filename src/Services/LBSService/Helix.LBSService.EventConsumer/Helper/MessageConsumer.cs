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
		private ManualResetEvent _resetEvent = null;
		private IConnection _connection;
		private IModel _channel;

		private readonly HttpClient _httpClient;
		private readonly string _queueName;
		private readonly string _exchange;


		public MessageConsumer(IService<TDto> service, string queueName, string exchange, HttpClient httpClient, ManualResetEvent resetEvent)
		{
			_service = service;
			_httpClient = httpClient;
			_queueName = queueName;
			_exchange = exchange;


			_resetEvent = resetEvent;

			// create a connection and open a channel, dispose them when done
			var factory = new ConnectionFactory
			{
				Uri = new Uri(ApplicationParameter.RabbitMQAdress)
			};

			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();

		}

		public async Task ProcessMessagesAsync()
		{
			await Task.Run(GetMessageFromQueue);

		}

		private async Task<bool> PostDtoToApiAsync(string dto, string apiEndpoint)
		{
			try
			{
				string apiUrl = ApplicationParameter.ApiAdress; // Replace with your actual API endpoint 

				StringContent content = new StringContent(dto, Encoding.UTF8, "application/json");

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
			var queueName = _queueName;
			bool durable = true;
			bool exclusive = false;
			bool autoDelete = false;

			try
			{
				Log.Information($" [*] {_queueName} Waiting for messages.");
				_channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);

				var consumer = new EventingBasicConsumer(_channel);

				consumer.Received += async (model, ea) =>
				{
					try
					{
						var body = ea.Body.ToArray();
						var message = Encoding.UTF8.GetString(body);
						Log.Information($" [x] Received {message}");

						bool result = await PostDtoToApiAsync(message, _service.GetApiEndpoint());

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


				// start consuming
				_ = _channel.BasicConsume(consumer, queueName);

				// Wait for the reset event and clean up when it triggers
				_resetEvent.WaitOne();
				Console.WriteLine("CancelEvent recieved, shutting down Consumer");
				_channel?.Close();
				_channel = null;
				_connection?.Close();
				_connection = null;

				 
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
