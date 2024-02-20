using Helix.EventBus.Base.Abstractions;
using Helix.NotificationService.Events;

namespace Helix.NotificationService
{
	public class Worker : BackgroundService
	{
		private readonly IEventBus _eventBus;
		private readonly ILogger<Worker> _logger;
		private readonly IServiceProvider _serviceProvider;
		public Worker(ILogger<Worker> logger, IEventBus eventBus, IServiceProvider serviceProvider)
		{
			_logger = logger;
			_eventBus = eventBus;
			_serviceProvider = serviceProvider; 
 		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				//if (_logger.IsEnabled(LogLevel.Information))
				//{
				//	_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
				//}

				_eventBus.Consume(new LOGOSuccessIntegrationEvent());
				_eventBus.Consume(new LOGOFailureIntegrationEvent());
				_eventBus.Consume(new SYSMessageIntegrationEvent());

				await Task.Delay(1000, stoppingToken);
			}
		}
	}
}
