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
    public class OutCountingTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<OutCountingTransactionInsertedIntegrationEvent>
    {
        private readonly ILogger<OutCountingTransactionInsertedIntegrationEventHandler> _logger;
        public OutCountingTransactionInsertedIntegrationEventHandler(ILogger<OutCountingTransactionInsertedIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        
        public Task Handle(OutCountingTransactionInsertedIntegrationEvent @event)
        {
            _logger.LogInformation("incounting transaction inserted started");
            return Task.CompletedTask;
        }
    }
}
