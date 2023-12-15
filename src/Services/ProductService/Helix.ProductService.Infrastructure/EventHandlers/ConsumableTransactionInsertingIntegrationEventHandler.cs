using Helix.EventBus.Base.Abstractions;
using Helix.ProductService.Domain.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Infrastructure.EventHandlers
{
    public class ConsumableTransactionInsertingIntegrationEventHandler :IIntegrationEventHandler<ConsumableTransactionInsertingIntegrationEvent>
    {
        private readonly ILogger<ConsumableTransactionInsertingIntegrationEventHandler> _logger;
        public ConsumableTransactionInsertingIntegrationEventHandler(ILogger<ConsumableTransactionInsertingIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(ConsumableTransactionInsertingIntegrationEvent @event)
        {
            _logger.LogInformation("consumable transaction inserting started");
            return Task.CompletedTask;
        }
    }
}
