using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using TestProject1.TestEvents.EventHandlers;
using TestProject1.TestEvents.Events;

namespace TestProject1
{
    public class EventBusTest
    {
        private ServiceCollection services;

        public EventBusTest()
        {
            services = new ServiceCollection();
            services.AddLogging(configure => configure.AddConsole());
        }


        [Fact]
        public void Test_RabbitMQ_Subscribe()
        {
            services.AddSingleton<IEventBus>(eb =>
            {
                return EventBusFactory.Create(GetRabbitMQConfig(), eb);
            });

            var serviceProvider = services.BuildServiceProvider();

            var eventBus = serviceProvider.GetRequiredService<IEventBus>();

            eventBus.Subscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();
            eventBus.UnSubscribe<OrderCreatedIntegrationEvent, OrderCreatedIntegrationEventHandler>();

        }

        [Fact]
        public void Test_RabbitMQ_SendMessage()
        {
            services.AddSingleton<IEventBus>(eb =>
            {
                return EventBusFactory.Create(GetRabbitMQConfig(), eb);
            });

            var serviceProvider = services.BuildServiceProvider();

            var eventBus = serviceProvider.GetRequiredService<IEventBus>();

            eventBus.Publish(new OrderCreatedIntegrationEvent(1));

        }

        private EventBusConfig GetRabbitMQConfig()
        {
            return new EventBusConfig
            {
                ConnectionRetryCount = 5,
                SubscriperClientAppName = "EventBus.UnitTest",
                DefaultTopicName = "HelixTopicName",
                EventBusType = EventBusType.RabbitMQ,
                EventNameSuffix = nameof(IntegrationEvent),
                Connection = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest"
                }
            };
        }
    }
}