using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class TransferTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<TransferTransactionInsertedIntegrationEvent>
	{
		public Task Handle(TransferTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
