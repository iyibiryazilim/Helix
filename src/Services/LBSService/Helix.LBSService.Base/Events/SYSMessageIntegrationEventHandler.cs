using Helix.EventBus.Base.Abstractions;
using Microsoft.Extensions.Logging;

namespace Helix.LBSService.Base.Events
{
	public class SYSMessageIntegrationEventHandler : IIntegrationEventHandler<SYSMessageIntegrationEvent>
	{
		private ILogger<SYSMessageIntegrationEventHandler> _logger;

		public SYSMessageIntegrationEventHandler(ILogger<SYSMessageIntegrationEventHandler> logger)
		{
			_logger = logger;
		}

		public Task Handle(SYSMessageIntegrationEvent @event)
		{
			return Task.CompletedTask;
		}
	}
}