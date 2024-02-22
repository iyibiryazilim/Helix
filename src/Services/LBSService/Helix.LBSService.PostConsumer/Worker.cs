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
			_eventBus.Consume(new ConsumableTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new InCountingTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new OutCountingTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new ProductionTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new PurchaseDispatchTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new PurchaseReturnDispatchTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new RetailSalesDispatchTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new RetailSalesReturnDispatchTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new TransferTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new WastageTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new WholeSalesDispatchTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new WholeSalesReturnDispatchTransactionInsertingIntegrationEvent());

			while (!stoppingToken.IsCancellationRequested)
			{
				if (_logger.IsEnabled(LogLevel.Information))
				{
					_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
				}
 
				await Task.Delay(10000, stoppingToken);
			}
		}
	}
}
