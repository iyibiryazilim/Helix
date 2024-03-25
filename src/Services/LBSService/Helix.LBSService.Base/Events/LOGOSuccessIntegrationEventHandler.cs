using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.Base.Events
{
	public class LOGOSuccessIntegrationEventHandler : IIntegrationEventHandler<LOGOSuccessIntegrationEvent>
	{
		public Task Handle(LOGOSuccessIntegrationEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}