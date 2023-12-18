using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.RabbitMQ;

namespace Helix.EventBus.Factory
{
	public static class EventBusFactory 
	{
        public static IEventBus Create(EventBusConfig config, IServiceProvider serviceProvider)
        {
            return config.EventBusType switch
            {
                EventBusType.AzureBusService => throw new NotImplementedException(),
                _ => new EventBusRabbitMQ(serviceProvider, config),
            };
        }
    }
}
