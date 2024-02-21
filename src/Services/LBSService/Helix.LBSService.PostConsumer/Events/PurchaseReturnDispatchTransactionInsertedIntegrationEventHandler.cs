using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class PurchaseReturnDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<PurchaseReturnDispatchTransactionInsertedIntegrationEvent>
	{
		public Task Handle(PurchaseReturnDispatchTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
