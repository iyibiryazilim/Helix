using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class SalesOrderInsertingIntegrationEventHandler : IIntegrationEventHandler<SalesOrderInsertingIntegrationEvent>
{
	private readonly ILogger<SalesOrderInsertingIntegrationEventHandler> _logger;
    public SalesOrderInsertingIntegrationEventHandler(ILogger<SalesOrderInsertingIntegrationEventHandler> logger)
    {
        _logger = logger;   
    }
    public Task Handle(SalesOrderInsertingIntegrationEvent @event)
	{
        
        _logger.LogInformation("sales order inserted started");
		return Task.CompletedTask;
	}
}
