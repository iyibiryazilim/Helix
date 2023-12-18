using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class RetailSalesReturnDispatchTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<RetailSalesReturnDispatchTransactionInsertingIntegrationEvent>
{
	private readonly ILogger<RetailSalesReturnDispatchTransactionInsertingIntegrationEventHandler> _logger;
    public RetailSalesReturnDispatchTransactionInsertingIntegrationEventHandler(ILogger<RetailSalesReturnDispatchTransactionInsertingIntegrationEventHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(RetailSalesReturnDispatchTransactionInsertingIntegrationEvent @event)
	{
		return Task.CompletedTask;
	}
}
