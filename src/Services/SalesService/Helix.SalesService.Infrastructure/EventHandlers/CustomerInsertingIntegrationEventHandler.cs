using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.EventHandlers
{
    public class CustomerInsertingIntegrationEventHandler : IIntegrationEventHandler<CustomerInsertingIntegrationEvent>
    {
        ILogger<CustomerInsertingIntegrationEventHandler> _logger;

        public CustomerInsertingIntegrationEventHandler(ILogger<CustomerInsertingIntegrationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CustomerInsertingIntegrationEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
