using Helix.EventBus.Base.Events;

namespace Helix.EventBus.Base.Abstractions;

public interface IIntegrationEventHandler<TIntegrationEvent> : IntegrationEventHandler where TIntegrationEvent : IntegrationEvent
{
	public Task Handle(TIntegrationEvent @event);
}

public interface IntegrationEventHandler
{
}