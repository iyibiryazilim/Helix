using Helix.EventBus.Base.Abstractions;
using Helix.PurchaseService.Domain.Events;

namespace Helix.PurchaseService.Infrastructure.EventHandlers;

public class PurchaseOrderInsertedIntegrationEventHandler : IIntegrationEventHandler<PurchaseOrderInsertingIntegrationEvent>
{
	public Task Handle(PurchaseOrderInsertingIntegrationEvent @event)
	{
		return Task.CompletedTask;
	}
}
