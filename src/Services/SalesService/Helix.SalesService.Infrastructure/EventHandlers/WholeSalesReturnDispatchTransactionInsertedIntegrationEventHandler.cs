using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class WholeSalesReturnDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<WholeSalesReturnDispatchTransactionInsertedIntegrationEvent>
{
	private readonly ILogger<WholeSalesReturnDispatchTransactionInsertedIntegrationEventHandler> _logger;
    public WholeSalesReturnDispatchTransactionInsertedIntegrationEventHandler(ILogger<WholeSalesReturnDispatchTransactionInsertedIntegrationEventHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(WholeSalesReturnDispatchTransactionInsertedIntegrationEvent @event)
	{
		throw new NotImplementedException();
	}
}
