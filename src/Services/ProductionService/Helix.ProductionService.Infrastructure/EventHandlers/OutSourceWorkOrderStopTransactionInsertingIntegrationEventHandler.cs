using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;

namespace Helix.ProductionService.Infrastructure.EventHandlers
{
	public class OutSourceWorkOrderStopTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<OutSourceWorkOrderStopTransactionInsertingIntegrationEvent>
	{
		public Task Handle(OutSourceWorkOrderStopTransactionInsertingIntegrationEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}