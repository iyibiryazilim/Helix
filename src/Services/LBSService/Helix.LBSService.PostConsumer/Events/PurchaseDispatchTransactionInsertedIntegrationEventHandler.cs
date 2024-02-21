using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class PurchaseDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<PurchaseDispatchTransactionInsertedIntegrationEvent>
	{
		public Task Handle(PurchaseDispatchTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
