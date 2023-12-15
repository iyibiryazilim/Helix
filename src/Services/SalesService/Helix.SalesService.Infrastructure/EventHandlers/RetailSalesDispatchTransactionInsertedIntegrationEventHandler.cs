using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class RetailSalesDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<RetailSalesDispatchTransactionInsertedIntegrationEvent>
{
	private readonly ILogger<RetailSalesDispatchTransactionInsertedIntegrationEventHandler> _logger;
    public RetailSalesDispatchTransactionInsertedIntegrationEventHandler(ILogger<RetailSalesDispatchTransactionInsertedIntegrationEventHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(RetailSalesDispatchTransactionInsertedIntegrationEvent @event)
	{
		throw new NotImplementedException();
	}
}
