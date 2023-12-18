using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class WholeSalesReturnDispatchTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<WholeSalesReturnDispatchTransactionInsertingIntegrationEvent>
{
	private readonly ILogger<WholeSalesReturnDispatchTransactionInsertingIntegrationEventHandler> _logger;
    public WholeSalesReturnDispatchTransactionInsertingIntegrationEventHandler(ILogger<WholeSalesReturnDispatchTransactionInsertingIntegrationEventHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(WholeSalesReturnDispatchTransactionInsertingIntegrationEvent @event)
	{
		return Task.CompletedTask;
	}
}
