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
    public class ProductionTransactionInsertedIntegrationEventHandler : IIntegrationEventHandler<ProductionTransactionInsertedIntegrationEvent>
    {
        private readonly ILogger<ProductionTransactionInsertedIntegrationEventHandler> _logger;
        public ProductionTransactionInsertedIntegrationEventHandler(ILogger<ProductionTransactionInsertedIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(ProductionTransactionInsertedIntegrationEvent @event)
        {
            _logger.LogInformation("production transaction inserted started");
            return Task.CompletedTask;
        }


    }
}
