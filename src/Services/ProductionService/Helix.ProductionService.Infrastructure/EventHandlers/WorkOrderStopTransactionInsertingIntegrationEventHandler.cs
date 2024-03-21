using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class WorkOrderStopTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<WorkOrderStopTransactionInsertingIntegrationEvent>
{
	private ILogger<WorkOrderStopTransactionInsertingIntegrationEventHandler> _logger;

	public WorkOrderStopTransactionInsertingIntegrationEventHandler(ILogger<WorkOrderStopTransactionInsertingIntegrationEventHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(WorkOrderStopTransactionInsertingIntegrationEvent @event)
	{
		_logger.LogInformation($"Stop transaction for work order inserting started");
		return Task.CompletedTask;
	}
}