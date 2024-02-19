using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.Base.Events
{
	public class SYSMessageIntegrationEventHandler : IIntegrationEventHandler<SYSMessageEvent>
	{
		public Task Handle(SYSMessageEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}
