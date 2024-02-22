using Helix.EventBus.Base.Abstractions;

namespace Helix.NotificationService.Events
{
	public class LOGOFailureIntegrationEventHandler : IIntegrationEventHandler<LOGOFailureIntegrationEvent>
	{
		private readonly ILogger<LOGOFailureIntegrationEventHandler> _logger;
		public LOGOFailureIntegrationEventHandler(ILogger<LOGOFailureIntegrationEventHandler> logger)
		{
			_logger = logger;
		}

		public Task Handle(LOGOFailureIntegrationEvent @event)
		{
			_logger.LogInformation("LOGOFailureIntegrationEvent Handled");
			return Task.CompletedTask;
		}
	}
}
