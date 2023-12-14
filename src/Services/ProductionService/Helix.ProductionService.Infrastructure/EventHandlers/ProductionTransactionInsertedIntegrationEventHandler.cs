using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class ProductionTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<ProductionTransactionInsertedIntegrationEvent>
{
	ILogger<ProductionTransactionInsertedIntegrationEventHandler> _logger;

	public ProductionTransactionInsertedIntegrationEventHandler(ILogger<ProductionTransactionInsertedIntegrationEventHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(ProductionTransactionInsertedIntegrationEvent @event)
	{
		_logger.LogInformation($"Production transaction inserted started");
		return Task.CompletedTask;
	}
}
