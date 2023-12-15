using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

		[Fact]
		public void Test_RabbitMQ_Consume()
		{
			services.AddSingleton<IEventBus>(eb =>
			{
				return EventBusFactory.Create(GetRabbitMQConfig(), eb);
			});

			var serviceProvider = services.BuildServiceProvider();

			var eventBus = serviceProvider.GetRequiredService<IEventBus>();

			eventBus.Consume(new TransferTransactionInsertedIntegrationEvent());

		}

		private EventBusConfig GetRabbitMQConfig()
        {
            return new EventBusConfig
            {
                ConnectionRetryCount = 5,
                SubscriperClientAppName = "ProductService",
                DefaultTopicName = "HelixTopicName",
                EventBusType = EventBusType.RabbitMQ,
                EventNameSuffix = nameof(IntegrationEvent),
    //            Connection = new ConnectionFactory
    //            {
				//	Uri = new Uri("amqps://oqhbtvgt:Zh4cCLQdL1U3_E5dtAA0TOh7vnYUVA7g@rattlesnake.rmq.cloudamqp.com/oqhbtvgt")
				//}
            };
        }
    }
}