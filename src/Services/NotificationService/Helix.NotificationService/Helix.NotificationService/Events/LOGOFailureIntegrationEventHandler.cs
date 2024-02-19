using Helix.EventBus.Base.Abstractions;

namespace Helix.NotificationService.Events
{
	public class LOGOFailureIntegrationEventHandler : IIntegrationEventHandler<LOGOFailureIntegrationEvent>
	{
		public Task Handle(LOGOFailureIntegrationEvent @event)
		{
			//Throw error to test error handling
			throw new Exception("Test Exception"); 
  		}
	}
}
