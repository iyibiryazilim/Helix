using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class RetailSalesDispatchTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<RetailSalesDispatchTransactionInsertingIntegrationEvent>
{
	private readonly ILogger<RetailSalesDispatchTransactionInsertingIntegrationEventHandler> _logger;
    public RetailSalesDispatchTransactionInsertingIntegrationEventHandler(ILogger<RetailSalesDispatchTransactionInsertingIntegrationEventHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(RetailSalesDispatchTransactionInsertingIntegrationEvent @event)
	{
		return Task.CompletedTask;
	}
}
