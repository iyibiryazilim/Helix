using Helix.EventBus.Base.Abstractions;
using System.Diagnostics;

namespace Helix.NotificationService.Events
{
	public class LOGOSuccessIntegrationEventHandler : IIntegrationEventHandler<LOGOSuccessIntegrationEvent>
	{
		public Task Handle(LOGOSuccessIntegrationEvent @event)
		{
			Debug.WriteLine("LOGOSuccessIntegrationEvent Handled");	
			return Task.CompletedTask;
		}
	}
}
