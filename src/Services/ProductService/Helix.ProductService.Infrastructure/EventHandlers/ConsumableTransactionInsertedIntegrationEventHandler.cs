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
    public class ConsumableTransactionInsertedIntegrationEventHandler :IIntegrationEventHandler<ConsumableTransactionInsertedIntegrationEvent>
    {
        private readonly ILogger<ConsumableTransactionInsertedIntegrationEventHandler> _logger;
        public ConsumableTransactionInsertedIntegrationEventHandler(ILogger<ConsumableTransactionInsertedIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(ConsumableTransactionInsertedIntegrationEvent @event)
        {
            _logger.LogInformation("consumable transaction inserted started");
            return Task.CompletedTask;
        }
    }
}
