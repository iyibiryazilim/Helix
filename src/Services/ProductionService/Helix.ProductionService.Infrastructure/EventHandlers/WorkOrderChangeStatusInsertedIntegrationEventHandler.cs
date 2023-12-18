using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class WorkOrderChangeStatusInsertedIntegrationEventHandler : IIntegrationEventHandler<WorkOrderChangeStatusInsertedIntegrationEvent>
{
	ILogger<WorkOrderChangeStatusInsertedIntegrationEventHandler> _logger;

	public WorkOrderChangeStatusInsertedIntegrationEventHandler(ILogger<WorkOrderChangeStatusInsertedIntegrationEventHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(WorkOrderChangeStatusInsertedIntegrationEvent @event)
	{
		_logger.LogInformation($"Work order change status inserting started");
		return Task.CompletedTask;
	}
}
