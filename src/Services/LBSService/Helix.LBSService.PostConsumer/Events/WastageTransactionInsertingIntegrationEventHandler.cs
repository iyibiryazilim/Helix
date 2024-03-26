using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.PostConsumer.Helper;
using System.Text;
using System.Text.Json;

namespace Helix.LBSService.PostConsumer.Events
{
	public class WastageTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<WastageTransactionInsertingIntegrationEvent>
	{
		private readonly IHttpClientService _httpClientService;
		private readonly ILogger<WastageTransactionInsertingIntegrationEventHandler> _logger;

		public WastageTransactionInsertingIntegrationEventHandler(IHttpClientService httpClientService, ILogger<WastageTransactionInsertingIntegrationEventHandler> logger)
		{
			_httpClientService = httpClientService;
			_logger = logger;
		}

		public async Task Handle(WastageTransactionInsertingIntegrationEvent @event)
		{
			var httpClient = _httpClientService.GetOrCreateHttpClient();
			try
			{
				string apiUrl = "/api/WastageTransaction/Insert"; // Replace with your actual API endpoint
				var json = JsonSerializer.Serialize(@event);

				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

				if (response.IsSuccessStatusCode)
				{
					_logger.LogInformation($" [>] Successfully posted DTO to API.");
				}
				else
				{
					_logger.LogError($" [!] Failed to post DTO to API. Status code: {response.StatusCode}");
				}
			}
			catch (HttpRequestException ex)
			{
				_logger.LogError($"Error in PostDtoToApiAsync: {ex.Message}");
				throw;
			}
			catch (JsonException ex)
			{
				_logger.LogError($"JsonException in PostDtoToApiAsync: {ex.Message}");
			}
			catch (Exception ex)
			{
				_logger.LogError($"Exception in PostDtoToApiAsync: {ex.Message} StackTrace: {ex.StackTrace} ");
			}
		}
	}
}