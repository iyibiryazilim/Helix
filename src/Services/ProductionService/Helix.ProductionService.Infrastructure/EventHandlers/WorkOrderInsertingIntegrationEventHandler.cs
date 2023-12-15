using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class WorkOrderInsertingIntegrationEventHandler : IIntegrationEventHandler<WorkOrderInsertingIntegrationEvent>
{
	private readonly ILogger<WorkOrderInsertingIntegrationEventHandler> _logger;

	public WorkOrderInsertingIntegrationEventHandler(ILogger<WorkOrderInsertingIntegrationEventHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(WorkOrderInsertingIntegrationEvent @event)
	{
		_logger.LogInformation($"Work order inserting started");
		return Task.CompletedTask;
	}
}
