using Helix.EventBus.Base.Abstractions;

namespace Helix.NotificationService.Events
{
	public class SYSMessageIntegrationEventHandler : IIntegrationEventHandler<SYSMessageIntegrationEvent>
	{
		private readonly ILogger<SYSMessageIntegrationEventHandler> _logger;
		public SYSMessageIntegrationEventHandler(ILogger<SYSMessageIntegrationEventHandler> logger)
		{
			_logger = logger;
		}
		public Task Handle(SYSMessageIntegrationEvent @event)
		{
			_logger.LogInformation("SYSMessageIntegrationEvent Handled"); 
			return Task.CompletedTask;
		}
	}
}
