﻿using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.PostConsumer.Helper;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;

namespace Helix.LBSService.PostConsumer.Events
{
	public class DemandInsertingIntegrationEventHandler : IIntegrationEventHandler<DemandInsertingIntegrationEvent>
	{
		private readonly IHttpClientService _httpClientService;
		private readonly ILogger<ConsumableTransactionInsertingIntegrationEventHandler> _logger;

		public DemandInsertingIntegrationEventHandler(IHttpClientService httpClientService, ILogger<ConsumableTransactionInsertingIntegrationEventHandler> logger)
		{
			_httpClientService = httpClientService;
			_logger = logger;
		}

		public async Task Handle(DemandInsertingIntegrationEvent @event)
		{
			var httpClient = _httpClientService.GetOrCreateHttpClient();
			try
			{
				string apiUrl = "/api/Demand/Insert"; // Replace with your actual API endpoint
				var json = JsonSerializer.Serialize(@event);

				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
				if (!response.IsSuccessStatusCode)
				{
					throw new HttpRequestException($"Failed to post DTO to API. Status Code: {response.StatusCode}");
				}
				string responseBody = await response.Content.ReadAsStringAsync();
				JObject jsonResponse = JObject.Parse(responseBody);

				bool isSuccess = jsonResponse["isSuccess"].Value<bool>();
				string message = jsonResponse["message"].Value<string>();
				if (isSuccess)
				{
					_logger.LogInformation($" [>] Successfully posted DTO to API.");
				}
				else
				{
					_logger.LogError($" [!] Failed to post DTO to API. Status Mess: {message} and JSON: {json}");
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