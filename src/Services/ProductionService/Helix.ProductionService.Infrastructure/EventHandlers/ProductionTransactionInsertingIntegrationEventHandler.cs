using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class ProductionTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<ProductionTransactionInsertingIntegrationEvent>
{
	ILogger<ProductionTransactionInsertingIntegrationEventHandler> _logger;

	public ProductionTransactionInsertingIntegrationEventHandler(ILogger<ProductionTransactionInsertingIntegrationEventHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(ProductionTransactionInsertingIntegrationEvent @event)
	{
		_logger.LogInformation($"Production transaction inserting started");
		return Task.CompletedTask;
	}
}
