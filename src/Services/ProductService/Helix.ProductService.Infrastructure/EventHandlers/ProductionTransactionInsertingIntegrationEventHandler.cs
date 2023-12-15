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
    public class ProductionTransactionInsertingIntegrationEventHandler : IIntegrationEventHandler<ProductionTransactionInsertingIntegrationEvent>
    {
        private readonly ILogger<ProductionTransactionInsertingIntegrationEventHandler> _logger;
        public ProductionTransactionInsertingIntegrationEventHandler(ILogger<ProductionTransactionInsertingIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(ProductionTransactionInsertingIntegrationEvent @event)
        {
            _logger.LogInformation("production transaction inserting started");
            return Task.CompletedTask;
        }


    }
}
