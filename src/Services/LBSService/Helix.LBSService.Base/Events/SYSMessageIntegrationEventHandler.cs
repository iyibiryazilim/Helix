using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.Base.Events
{
	public class SYSMessageIntegrationEventHandler : IIntegrationEventHandler<SYSMessageIntegrationEvent>
	{
		public Task Handle(SYSMessageIntegrationEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}
