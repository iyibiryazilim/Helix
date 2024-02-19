using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.Base.Events
{
	public class LOGOSuccessIntegrationEventHandler : IIntegrationEventHandler<LOGOSuccessEvent>
	{
		public Task Handle(LOGOSuccessEvent @event)
		{
				return Task.CompletedTask;
		}
	}
}
