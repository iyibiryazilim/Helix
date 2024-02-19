using Helix.EventBus.Base.Abstractions;

namespace Helix.NotificationService.Events
{
	public class SYSMessageIntegrationEventHandler : IIntegrationEventHandler<SYSMessageIntegrationEvent>
	{
		public Task Handle(SYSMessageIntegrationEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}
