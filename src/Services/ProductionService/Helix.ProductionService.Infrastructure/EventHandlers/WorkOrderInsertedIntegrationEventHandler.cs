using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.EventHandlers;

public class WorkOrderInsertedIntegrationEventHandler : IIntegrationEventHandler<WorkOrderInsertedIntegrationEvent>
{
	private readonly ILogger<WorkOrderInsertedIntegrationEventHandler> _logger;

	public WorkOrderInsertedIntegrationEventHandler(ILogger<WorkOrderInsertedIntegrationEventHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(WorkOrderInsertedIntegrationEvent @event)
	{
		_logger.LogInformation($"Work order inserted started");
		return Task.CompletedTask;
	}
}
