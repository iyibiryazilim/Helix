using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class WholeSalesReturnDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<WholeSalesReturnDispatchTransactionInsertedIntegrationEvent>
	{
		public Task Handle(WholeSalesReturnDispatchTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
