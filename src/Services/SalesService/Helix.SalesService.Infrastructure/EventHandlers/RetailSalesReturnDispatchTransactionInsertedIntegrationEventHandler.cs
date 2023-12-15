using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class RetailSalesReturnDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<RetailSalesReturnDispatchTransactionInsertedIntegrationEvent>
{
	private readonly ILogger<RetailSalesReturnDispatchTransactionInsertedIntegrationEventHandler> _logger;
    public RetailSalesReturnDispatchTransactionInsertedIntegrationEventHandler(ILogger<RetailSalesReturnDispatchTransactionInsertedIntegrationEventHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(RetailSalesReturnDispatchTransactionInsertedIntegrationEvent @event)
	{
		throw new NotImplementedException();
	}
}
