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
			try
			{
				await StartRabbitMQ(stoppingToken);
			}
			catch (OperationCanceledException)
			{
				// When the stopping token is canceled, for example, a call made from services.msc,
				// we shouldn't exit with a non-zero exit code. In other words, this is expected...
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "{Message}", ex.Message);
				Environment.Exit(1);
			}
		}

		private async Task StartRabbitMQ(CancellationToken stoppingToken)
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
			_eventBus.Consume(new WorkOrderChangeStatusInsertedIntegrationEvent());
			_eventBus.Consume(new StopTransactionForWorkOrderInsertedIntegrationEvent());
			_eventBus.Consume(new PurchaseOrderInsertingIntegrationEvent());
			_eventBus.Consume(new SalesOrderInsertingIntegrationEvent());
			_eventBus.Consume(new CustomerInsertingIntegrationEvent());
			_eventBus.Consume(new VariantInsertingIntegrationEvent());
			_eventBus.Consume(new WorkOrderStopTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new WorkOrderInsertActualQuantityIntegrationEvent());
			_eventBus.Consume(new OutSourceWorkOrderStopTransactionInsertingIntegrationEvent());
			_eventBus.Consume(new OutSourceWorkOrderInsertActualQuantityIntegrationEvent());
			_eventBus.Consume(new DemandInsertingIntegrationEvent());
			_eventBus.Consume(new OutSourceWorkOrderChangeStatusInsertedIntegrationEvent());

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