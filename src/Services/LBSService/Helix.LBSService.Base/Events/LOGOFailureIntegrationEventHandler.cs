using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.Base.Events
{
	public class LOGOFailureIntegrationEventHandler : IIntegrationEventHandler<LOGOFailureEvent>
	{
		public Task Handle(LOGOFailureEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}
