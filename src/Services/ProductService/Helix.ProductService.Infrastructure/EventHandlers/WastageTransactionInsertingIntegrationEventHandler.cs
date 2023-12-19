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
    public class WastageTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<WastageTransactionInsertingIntegrationEvent>
    {
        private readonly ILogger<WastageTransactionInsertingIntegrationEventHandler> _logger;
        public WastageTransactionInsertingIntegrationEventHandler(ILogger<WastageTransactionInsertingIntegrationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(WastageTransactionInsertingIntegrationEvent @event)
        {
            _logger.LogInformation("wastage transaction inserting started");
            return Task.CompletedTask;
        }
    }
}
