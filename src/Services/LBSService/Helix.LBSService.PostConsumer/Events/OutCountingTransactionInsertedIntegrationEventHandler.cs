using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class OutCountingTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<OutCountingTransactionInsertedIntegrationEvent>
	{
		public Task Handle(OutCountingTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
