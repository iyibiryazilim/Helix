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
    public class TransferTransactionInsertingIntegrationEventHandler :IIntegrationEventHandler<TransferTransactionInsertingIntegrationEvent>
    {
        private readonly ILogger<TransferTransactionInsertingIntegrationEventHandler> _logger;
        public TransferTransactionInsertingIntegrationEventHandler(ILogger<TransferTransactionInsertingIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(TransferTransactionInsertingIntegrationEvent @event)
        {
            _logger.LogInformation("transfer transaction inserting started");
            return Task.CompletedTask;
        }

    }
}
