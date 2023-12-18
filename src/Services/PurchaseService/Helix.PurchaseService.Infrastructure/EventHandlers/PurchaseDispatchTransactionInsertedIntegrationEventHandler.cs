using Helix.EventBus.Base.Abstractions;
using Helix.PurchaseService.Domain.Events;

namespace Helix.PurchaseService.Infrastructure.EventHandlers;

public class PurchaseDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<PurchaseDispatchTransactionInsertedIntegrationEvent>
{
	public Task Handle(PurchaseDispatchTransactionInsertedIntegrationEvent @event)
	{
		return Task.CompletedTask;
	}
}
