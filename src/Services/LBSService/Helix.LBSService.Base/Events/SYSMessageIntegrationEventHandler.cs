using Helix.EventBus.Base.Abstractions;
using Microsoft.Extensions.Logging;

namespace Helix.LBSService.Base.Events
{
	public class SYSMessageIntegrationEventHandler : IIntegrationEventHandler<SYSMessageIntegrationEvent>
	{
		ILogger<SYSMessageIntegrationEventHandler> _logger;
		public SYSMessageIntegrationEventHandler(ILogger<SYSMessageIntegrationEventHandler> logger)
		{
			_logger = logger;
		}
		public Task Handle(SYSMessageIntegrationEvent @event)
		{
			_logger.LogInformation($"SYSMessageIntegrationEvent handled: FicheId: {@event.FicheId}, IsSucces: {@event.IsSucces}, Message: {@event.Message}, ApplicationOwner: {@event.ApplicationOwner}, Dto: {@event.Dto}");
			return Task.CompletedTask;
		}
	}
}
