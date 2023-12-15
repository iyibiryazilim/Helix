using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers;

public class WholeSalesDispatchTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<WholeSalesDispatchTransactionInsertedIntegrationEvent>
{
	private readonly ILogger<WholeSalesDispatchTransactionInsertedIntegrationEventHandler> _logger;
    public WholeSalesDispatchTransactionInsertedIntegrationEventHandler(ILogger<WholeSalesDispatchTransactionInsertedIntegrationEventHandler> logger)
    {
        _logger = logger;   
    }
    public Task Handle(WholeSalesDispatchTransactionInsertedIntegrationEvent @event)
	{
		throw new NotImplementedException();
	}
}
