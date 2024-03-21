using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;

namespace Helix.ProductionService.Infrastructure.EventHandlers
{
	public class OutSourceWorkOrderChangeStatusInsertedIntegrationEventHandler : IIntegrationEventHandler<OutSourceWorkOrderChangeStatusInsertedIntegrationEvent>
	{
		public Task Handle(OutSourceWorkOrderChangeStatusInsertedIntegrationEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}