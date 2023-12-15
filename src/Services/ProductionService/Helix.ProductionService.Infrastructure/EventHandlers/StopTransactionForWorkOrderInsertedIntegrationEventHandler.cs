using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class StopTransactionForWorkOrderInsertedIntegrationEventHandler : IIntegrationEventHandler<StopTransactionForWorkOrderInsertedIntegrationEvent>
{
	ILogger<StopTransactionForWorkOrderInsertedIntegrationEventHandler> _logger;
	public StopTransactionForWorkOrderInsertedIntegrationEventHandler(ILogger<StopTransactionForWorkOrderInsertedIntegrationEventHandler> logger)
	{
		_logger = logger;
	}
	public Task Handle(StopTransactionForWorkOrderInsertedIntegrationEvent @event)
	{
		_logger.LogInformation($"Stop transaction for work order inserting started");
		return Task.CompletedTask;
	}
}
