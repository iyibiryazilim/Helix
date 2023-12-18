using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class WorkOrdersInsertedIntegrationEventHandler : IIntegrationEventHandler<WorkOrdersInsertedIntegrationEvent>
{
	ILogger<WorkOrdersInsertedIntegrationEventHandler> _logger;

	public WorkOrdersInsertedIntegrationEventHandler(ILogger<WorkOrdersInsertedIntegrationEventHandler> logger)
	{
		_logger = logger;
	}
	public Task Handle(WorkOrdersInsertedIntegrationEvent @event)
	{
		_logger.LogInformation($"Work orders inserting started");
		return Task.CompletedTask;
	}
}
