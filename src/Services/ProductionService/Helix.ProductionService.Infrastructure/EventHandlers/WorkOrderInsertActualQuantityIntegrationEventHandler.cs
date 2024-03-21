using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class WorkOrderInsertActualQuantityIntegrationEventHandler : IIntegrationEventHandler<WorkOrderInsertActualQuantityIntegrationEvent>
{
	private readonly ILogger<WorkOrderInsertActualQuantityIntegrationEventHandler> _logger;

	public WorkOrderInsertActualQuantityIntegrationEventHandler(ILogger<WorkOrderInsertActualQuantityIntegrationEventHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(WorkOrderInsertActualQuantityIntegrationEvent @event)
	{
		_logger.LogInformation($"Work order inserting started");
		return Task.CompletedTask;
	}
}