using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;

namespace Helix.ProductionService.Infrastructure.EventHandlers
{
	public class OutSourceWorkOrderInsertActualQuantityIntegrationEventHandler : IIntegrationEventHandler<OutSourceWorkOrderInsertActualQuantityIntegrationEvent>
	{
		public Task Handle(OutSourceWorkOrderInsertActualQuantityIntegrationEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}