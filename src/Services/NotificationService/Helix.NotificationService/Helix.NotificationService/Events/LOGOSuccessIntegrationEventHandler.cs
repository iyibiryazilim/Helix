using Helix.EventBus.Base.Abstractions;
using System.Diagnostics;

namespace Helix.NotificationService.Events
{
	public class LOGOSuccessIntegrationEventHandler : IIntegrationEventHandler<LOGOSuccessIntegrationEvent>
	{
		private readonly ILogger<LOGOSuccessIntegrationEventHandler> _logger;
		public LOGOSuccessIntegrationEventHandler(ILogger<LOGOSuccessIntegrationEventHandler> logger)
		{
			_logger = logger;
		}

		public Task Handle(LOGOSuccessIntegrationEvent @event)
		{
			_logger.LogInformation("LOGOSuccessIntegrationEvent Handled");	
			return Task.CompletedTask;
		}
	}
}
