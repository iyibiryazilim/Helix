using Helix.EventBus.Base.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Helix.EventBus.Base.Abstractions
{
	public interface IEventBus
	{
		void Publish(IntegrationEvent @event);

		void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

		void UnSubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

		void Consume(IntegrationEvent @event);
		EventingBasicConsumer GetConsumer();
		IModel GetConsumerChannel();

	}
}
