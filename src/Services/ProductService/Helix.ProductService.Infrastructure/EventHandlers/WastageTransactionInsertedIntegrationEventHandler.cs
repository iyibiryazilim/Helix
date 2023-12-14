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
    public class WastageTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<WastageTransactionInsertedIntegrationEvent>
    {
        private readonly ILogger<WastageTransactionInsertedIntegrationEventHandler> _logger;
        public WastageTransactionInsertedIntegrationEventHandler(ILogger<WastageTransactionInsertedIntegrationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(WastageTransactionInsertedIntegrationEvent @event)
        {
            _logger.LogInformation("wastage transaction inserted started");
            return Task.CompletedTask;
        }
    }
}
