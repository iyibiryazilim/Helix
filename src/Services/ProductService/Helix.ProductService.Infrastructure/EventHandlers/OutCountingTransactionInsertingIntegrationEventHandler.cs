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
    public class OutCountingTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<OutCountingTransactionInsertingIntegrationEvent>
    {
        private readonly ILogger<OutCountingTransactionInsertingIntegrationEventHandler> _logger;
        public OutCountingTransactionInsertingIntegrationEventHandler(ILogger<OutCountingTransactionInsertingIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        
        public Task Handle(OutCountingTransactionInsertingIntegrationEvent @event)
        {
            _logger.LogInformation("incounting transaction inserting started");
            return Task.CompletedTask;
        }
    }
}
