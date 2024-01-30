using Helix.EventBus.Base.Abstractions;
using Helix.ProductService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.EventHandlers
{
    public class OutCountingTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<OutCountingTransactionInsertingIntegrationEvent>
    {
        private readonly ILogger<OutCountingTransactionInsertingIntegrationEventHandler> _logger;
        public OutCountingTransactionInsertingIntegrationEventHandler(ILogger<OutCountingTransactionInsertingIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(OutCountingTransactionInsertingIntegrationEvent @event)
        {
            _logger.LogInformation("outcounting transaction inserting started");
            return Task.CompletedTask;
        }
    }
}
