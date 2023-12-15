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
    public class TransferTransactionInsertedIntegrationEventHandler :IIntegrationEventHandler<TransferTransactionInsertedIntegrationEvent>
    {
        private readonly ILogger<TransferTransactionInsertedIntegrationEventHandler> _logger;
        public TransferTransactionInsertedIntegrationEventHandler(ILogger<TransferTransactionInsertedIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(TransferTransactionInsertedIntegrationEvent @event)
        {
            _logger.LogInformation("transfer transaction inserted started");
            return Task.CompletedTask;
        }

    }
}
