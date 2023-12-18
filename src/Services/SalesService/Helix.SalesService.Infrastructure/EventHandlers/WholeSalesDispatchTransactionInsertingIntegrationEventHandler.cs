using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class WholeSalesDispatchTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<WholeSalesDispatchTransactionInsertingIntegrationEvent>
{
	private readonly ILogger<WholeSalesDispatchTransactionInsertingIntegrationEventHandler> _logger;
    public WholeSalesDispatchTransactionInsertingIntegrationEventHandler(ILogger<WholeSalesDispatchTransactionInsertingIntegrationEventHandler> logger)
    {
        _logger = logger;   
    }
    public Task Handle(WholeSalesDispatchTransactionInsertingIntegrationEvent @event)
	{
		return Task.CompletedTask;
	}
}
