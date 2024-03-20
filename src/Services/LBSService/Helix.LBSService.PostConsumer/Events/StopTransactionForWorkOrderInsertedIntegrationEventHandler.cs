﻿using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.PostConsumer.Helper;
using System.Text;
using System.Text.Json;

namespace Helix.LBSService.PostConsumer.Events
{
    public  class StopTransactionForWorkOrderInsertedIntegrationEventHandler : IIntegrationEventHandler<StopTransactionForWorkOrderInsertedIntegrationEvent>
    {
        readonly IHttpClientService _httpClientService;
        readonly ILogger<WorkOrderChangeStatusInsertedIntegrationEventHandler> _logger;
        public StopTransactionForWorkOrderInsertedIntegrationEventHandler(IHttpClientService httpClientService, ILogger<WorkOrderChangeStatusInsertedIntegrationEventHandler> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
        }
        public  async Task Handle(StopTransactionForWorkOrderInsertedIntegrationEvent @event)
        {
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            try
            {
                string apiUrl = "/api/StopTransaction"; // Replace with your actual API endpoint 
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