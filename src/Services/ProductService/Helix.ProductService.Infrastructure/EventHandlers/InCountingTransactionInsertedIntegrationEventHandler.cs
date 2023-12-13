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
    public class InCountingTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<InCountingTransactionInsertedIntegrationEvent>
    {
        private readonly ILogger<InCountingTransactionInsertedIntegrationEventHandler> _logger;
        public InCountingTransactionInsertedIntegrationEventHandler(ILogger<InCountingTransactionInsertedIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(InCountingTransactionInsertedIntegrationEvent @event)
        {
            _logger.LogInformation("consumable transaction inserted started");
            return Task.CompletedTask;
        }
    }
}
