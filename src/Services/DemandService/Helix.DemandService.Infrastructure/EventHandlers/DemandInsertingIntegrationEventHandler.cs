using Helix.DemandService.Domain.Events;
using Helix.EventBus.Base.Abstractions;

namespace Helix.DemandService.Infrastructure.EventHandlers
{
	public class DemandInsertingIntegrationEventHandler : IIntegrationEventHandler<DemandInsertingIntegrationEvent>
	{
		public Task Handle(DemandInsertingIntegrationEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}