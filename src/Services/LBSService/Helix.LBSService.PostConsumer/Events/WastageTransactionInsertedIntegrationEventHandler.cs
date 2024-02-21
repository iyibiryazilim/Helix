using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class WastageTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<WastageTransactionInsertedIntegrationEvent>
	{
		public Task Handle(WastageTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
