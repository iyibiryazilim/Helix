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
    public class InCountingTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<InCountingTransactionInsertingIntegrationEvent>
    {
        private readonly ILogger<InCountingTransactionInsertingIntegrationEventHandler> _logger;
        public InCountingTransactionInsertingIntegrationEventHandler(ILogger<InCountingTransactionInsertingIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(InCountingTransactionInsertingIntegrationEvent @event)
        {
            _logger.LogInformation("incounting transaction inserting started");
            return Task.CompletedTask;
        }
    }
}
