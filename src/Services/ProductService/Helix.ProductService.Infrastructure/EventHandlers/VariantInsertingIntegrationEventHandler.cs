using Helix.EventBus.Base.Abstractions;
using Helix.ProductService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.EventHandlers
{
	public class VariantInsertingIntegrationEventHandler : IIntegrationEventHandler<VariantInsertingIntegrationEvent>
	{
		private readonly ILogger<VariantInsertingIntegrationEventHandler> _logger;

		public VariantInsertingIntegrationEventHandler(ILogger<VariantInsertingIntegrationEventHandler> logger)
		{
			_logger = logger;
		}

		public Task Handle(VariantInsertingIntegrationEvent @event)
		{
			_logger.LogInformation("transfer transaction inserting started");
			return Task.CompletedTask;
		}
	}
}