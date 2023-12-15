using Helix.EventBus.Base.Abstractions;
using TestProject1.TestEvents.Events;

namespace TestProject1.TestEvents.EventHandlers
{
	public class TransferTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<TransferTransactionInsertedIntegrationEvent>
	{
		public Task Handle(TransferTransactionInsertedIntegrationEvent @event)
		{
			Console.WriteLine($"Handle method worked with {@event.Id}");
			return Task.CompletedTask;
		}
	}
}
