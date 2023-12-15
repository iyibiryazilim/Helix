using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class ProductionTransactionLineInsertedIntegrationEventHandler : IIntegrationEventHandler<ProductionTransactionLineInsertedIntegrationEvent>
{
	ILogger<ProductionTransactionLineInsertedIntegrationEventHandler> _logger;

	public ProductionTransactionLineInsertedIntegrationEventHandler(ILogger<ProductionTransactionLineInsertedIntegrationEventHandler> logger)
	{
		_logger = logger;
	}
	public Task Handle(ProductionTransactionLineInsertedIntegrationEvent @event)
	{
		_logger.LogInformation($"Production transaction line inserted started");
		return Task.CompletedTask;
	}
}
