using Helix.EventBus.Base.Abstractions;
using Helix.PurchaseService.Domain.Events;

namespace Helix.PurchaseService.Infrastructure.EventHandlers;

public class PurchaseReturnDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<PurchaseReturnDispatchTransactionInsertedIntegrationEvent>
{
	public Task Handle(PurchaseReturnDispatchTransactionInsertedIntegrationEvent @event)
	{
		return Task.CompletedTask;
	}
}
