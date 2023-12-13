using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class SalesOrderInsertedIntegrationEventHandler : IIntegrationEventHandler<SalesOrderInsertedIntegrationEvent>
{
	private readonly ILogger<SalesOrderInsertedIntegrationEventHandler> _logger;
    public SalesOrderInsertedIntegrationEventHandler(ILogger<SalesOrderInsertedIntegrationEventHandler> logger)
    {
        _logger = logger;   
    }
    public Task Handle(SalesOrderInsertedIntegrationEvent @event)
	{
        _logger.LogInformation("sales order inserted started");
		return Task.CompletedTask;
	}
}
