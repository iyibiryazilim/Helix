using Helix.EventBus.Base.Abstractions;

namespace Helix.LBSService.PostConsumer.Events
{
	public class ProductionTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<ProductionTransactionInsertedIntegrationEvent>
	{
		public Task Handle(ProductionTransactionInsertedIntegrationEvent @event)
		{
			throw new NotImplementedException();
		}
	}
}
