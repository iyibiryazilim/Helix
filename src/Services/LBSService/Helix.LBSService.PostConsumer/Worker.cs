using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.PostConsumer.Events;

namespace Helix.LBSService.PostConsumer
{
	public class Worker : BackgroundService
	{
		private readonly IEventBus _eventBus;
		private readonly ILogger<Worker> _logger;
		public Worker(ILogger<Worker> logger, IEventBus eventBus)
		{
			_logger = logger;
			_eventBus = eventBus;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				//if (_logger.IsEnabled(LogLevel.Information))
				//{
				//	_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
				//}

				_eventBus.Consume(new ConsumableTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new InCountingTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new OutCountingTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new ProductionTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new PurchaseDispatchTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new PurchaseReturnDispatchTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new RetailSalesDispatchTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new RetailSalesReturnDispatchTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new TransferTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new WastageTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new WholeSalesDispatchTransactionInsertedIntegrationEvent());
				_eventBus.Consume(new WholeSalesReturnDispatchTransactionInsertedIntegrationEvent());



				await Task.Delay(1000, stoppingToken);
			}
		}
	}
}
