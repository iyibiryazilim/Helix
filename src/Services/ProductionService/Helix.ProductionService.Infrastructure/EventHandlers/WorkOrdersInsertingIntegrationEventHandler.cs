using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class WorkOrdersInsertingIntegrationEventHandler : IIntegrationEventHandler<WorkOrdersInsertingIntegrationEvent>
{
	ILogger<WorkOrdersInsertingIntegrationEventHandler> _logger;

	public WorkOrdersInsertingIntegrationEventHandler(ILogger<WorkOrdersInsertingIntegrationEventHandler> logger)
	{
		_logger = logger;
	}
	public Task Handle(WorkOrdersInsertingIntegrationEvent @event)
	{
		_logger.LogInformation($"Work orders inserting started");
		return Task.CompletedTask;
	}
}
