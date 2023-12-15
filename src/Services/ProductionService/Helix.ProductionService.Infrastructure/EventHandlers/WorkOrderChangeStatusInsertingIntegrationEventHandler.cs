using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class WorkOrderChangeStatusInsertingIntegrationEventHandler : IIntegrationEventHandler<WorkOrderChangeStatusInsertingIntegrationEvent>
{
	ILogger<WorkOrderChangeStatusInsertingIntegrationEventHandler> _logger;

	public WorkOrderChangeStatusInsertingIntegrationEventHandler(ILogger<WorkOrderChangeStatusInsertingIntegrationEventHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(WorkOrderChangeStatusInsertingIntegrationEvent @event)
	{
		_logger.LogInformation($"Work order change status inserting started");
		return Task.CompletedTask;
	}
}
