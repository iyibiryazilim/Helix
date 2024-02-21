using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class InCountingTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<InCountingTransactionInsertedIntegrationEvent>
	{
		public Task Handle(InCountingTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	} 
}
