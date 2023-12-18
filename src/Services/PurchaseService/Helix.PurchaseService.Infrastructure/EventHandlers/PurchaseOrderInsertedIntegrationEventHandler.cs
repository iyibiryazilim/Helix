using Helix.EventBus.Base.Abstractions;
using Helix.PurchaseService.Domain.Events;

namespace Helix.PurchaseService.Infrastructure.EventHandlers;

public class PurchaseOrderInsertedIntegrationEventHandler : IIntegrationEventHandler<PurchaseOrderInsertedIntegrationEvent>
{
	public Task Handle(PurchaseOrderInsertedIntegrationEvent @event)
	{
		return Task.CompletedTask;
	}
}
