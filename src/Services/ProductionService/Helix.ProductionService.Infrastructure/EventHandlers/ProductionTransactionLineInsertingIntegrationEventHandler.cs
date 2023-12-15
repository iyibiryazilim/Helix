using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class ProductionTransactionLineInsertingIntegrationEventHandler : IIntegrationEventHandler<ProductionTransactionLineInsertingIntegrationEvent>
{
	ILogger<ProductionTransactionLineInsertingIntegrationEventHandler> _logger;

	public ProductionTransactionLineInsertingIntegrationEventHandler(ILogger<ProductionTransactionLineInsertingIntegrationEventHandler> logger)
	{
		_logger = logger;
	}
	public Task Handle(ProductionTransactionLineInsertingIntegrationEvent @event)
	{
		_logger.LogInformation($"Production transaction line inserting started");
		return Task.CompletedTask;
	}
}
