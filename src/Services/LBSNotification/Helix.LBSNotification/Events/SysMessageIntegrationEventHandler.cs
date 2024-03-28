using Helix.EventBus.Base.Abstractions;
using Helix.LBSNotification.Dto;
using Helix.LBSNotification.Helpers.AuthenticationHelper;
using Helix.LBSNotification.Helpers.HttpClientHelper;
using Helix.LBSNotification.Helpers.ResponseHelper;
using Newtonsoft.Json;
using System.Text;

namespace Helix.LBSNotification.Events
{
    public class SYSMessageIntegrationEventHandler : IIntegrationEventHandler<SYSMessageIntegrationEvent>
    {
        IHttpClientService _httpClientService;
        ILogger<SYSMessageIntegrationEventHandler> _logger;
        IAuthenticateService _authenticationService;

        public SYSMessageIntegrationEventHandler(IHttpClientService httpClientService, ILogger<SYSMessageIntegrationEventHandler> logger, IAuthenticateService authenticateService)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _authenticationService = authenticateService;
        }
        public async Task Handle(SYSMessageIntegrationEvent @event)
        {
            try
            {
                if (@event is not null)
                {
                    var httpclient = _httpClientService.GetOrCreateHttpClient();


                    var dto = new NotificationResult()
                    {
                        Owner = @event.Owner,
                        Content = @event.Content.ToString()
                    };

                    HttpResponseMessage response = await httpclient.PostAsync("helix/notification/NotificationResult", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));


                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("SYSMessageIntegrationEvent Handled");
                    }
                    else
                    {
                        var test = await response.RequestMessage.Content.ReadAsStringAsync();
                        _logger.LogError($" [!] Failed to post DTO to API. Status code: {response.StatusCode}");
                    }
                }
                else
                {
                    _logger.LogInformation("SYSMessageIntegrationEvent is null");
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
