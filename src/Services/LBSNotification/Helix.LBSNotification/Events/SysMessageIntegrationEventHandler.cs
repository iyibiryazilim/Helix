using Helix.EventBus.Base.Abstractions;
using Helix.LBSNotification.Helpers.HttpClientHelper;

namespace Helix.LBSNotification.Events
{
    public class SysMessageIntegrationEventHandler : IIntegrationEventHandler<SysMessageIntegrationEvent>
    {
        IHttpClientService _httpClientService;
        ILogger<SysMessageIntegrationEventHandler> _logger;

        public SysMessageIntegrationEventHandler(IHttpClientService httpClientService,ILogger<SysMessageIntegrationEventHandler> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
        }
        public Task Handle(SysMessageIntegrationEvent @event)
        {
            _logger.LogInformation("SysMessage Handled");
            return Task.CompletedTask;
        }
    }
}
