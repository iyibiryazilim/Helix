using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class RetailSalesReturnDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<RetailSalesReturnDispatchTransactionInsertedIntegrationEvent>
	{
		public Task Handle(RetailSalesReturnDispatchTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
