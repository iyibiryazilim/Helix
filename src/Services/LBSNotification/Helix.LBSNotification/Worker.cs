using Helix.EventBus.Base.Abstractions;
using Helix.LBSNotification.Events;

namespace Helix.NotificationService
{
    public class Worker : BackgroundService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger, IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await StartRabbitMQ(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);

                Environment.Exit(1);
            }

        }

        private async Task StartRabbitMQ(CancellationToken stoppingToken)
        {
            _eventBus.Consume(new SYSMessageIntegrationEvent());
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
