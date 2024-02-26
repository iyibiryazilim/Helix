using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.Base.Events
{
	public class LOGOFailureIntegrationEventHandler : IIntegrationEventHandler<LOGOFailureIntegrationEvent>
	{
		
		public Task Handle(LOGOFailureIntegrationEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}
