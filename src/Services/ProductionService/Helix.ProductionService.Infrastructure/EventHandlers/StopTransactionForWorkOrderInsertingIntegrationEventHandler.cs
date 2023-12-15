using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class StopTransactionForWorkOrderInsertingIntegrationEventHandler : IIntegrationEventHandler<StopTransactionForWorkOrderInsertingIntegrationEvent>
{
	ILogger<StopTransactionForWorkOrderInsertingIntegrationEventHandler> _logger;
	public StopTransactionForWorkOrderInsertingIntegrationEventHandler(ILogger<StopTransactionForWorkOrderInsertingIntegrationEventHandler> logger)
	{
		_logger = logger;
	}
	public Task Handle(StopTransactionForWorkOrderInsertingIntegrationEvent @event)
	{
		_logger.LogInformation($"Stop transaction for work order inserting started");
		return Task.CompletedTask;
	}
}
