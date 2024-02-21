using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class RetailSalesDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<RetailSalesDispatchTransactionInsertedIntegrationEvent>
	{
		public Task Handle(RetailSalesDispatchTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
