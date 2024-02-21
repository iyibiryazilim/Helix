using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class WholeSalesDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<WholeSalesDispatchTransactionInsertedIntegrationEvent>
	{
		public Task Handle(WholeSalesDispatchTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
