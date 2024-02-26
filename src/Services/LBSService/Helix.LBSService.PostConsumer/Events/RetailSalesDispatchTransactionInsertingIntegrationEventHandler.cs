﻿using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.PostConsumer.Helper;
using System.Text;
using System.Text.Json;

namespace Helix.LBSService.PostConsumer.Events
{
	public class RetailSalesDispatchTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<RetailSalesDispatchTransactionInsertingIntegrationEvent>
	{
		readonly IHttpClientService _httpClientService;
		readonly ILogger<RetailSalesDispatchTransactionInsertingIntegrationEventHandler> _logger;
		public RetailSalesDispatchTransactionInsertingIntegrationEventHandler(IHttpClientService httpClientService, ILogger<RetailSalesDispatchTransactionInsertingIntegrationEventHandler> logger)
		{
			_httpClientService = httpClientService;
			_logger = logger;
		}
		public async Task Handle(RetailSalesDispatchTransactionInsertingIntegrationEvent @event)
		{
			var httpClient = _httpClientService.GetOrCreateHttpClient();
			try
			{
				string apiUrl = "/api/RetailSalesDispatchTransaction/Insert"; // Replace with your actual API endpoint 
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
				_logger.LogError($"Error in PostDtoToApiAsync: {ex.Message}");
				throw;

			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in PostDtoToApiAsync: {ex.Message}");
				throw;

			}

		}
	}
}
