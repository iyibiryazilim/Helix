using Helix.EventBus.Base.Events;

namespace Helix.EventBus.Base.Abstractions
{
    public  interface IEventBusSubscriptionManager
    {
        bool isEmpty { get; }

        event EventHandler<string> OnEventRemoved;

        void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        void RemoveSubscription<T, TH>() where TH : IIntegrationEventHandler<T> where T : IntegrationEvent;

        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;

        bool HasSubscriptionsForEvent(string eventName);

        Type GetEventTypeByName(string eventName);

        void Clear();

        IEnumerable<SubscriptionInfo> GetHandlerForEvent<T>() where T : IntegrationEvent;

        IEnumerable<SubscriptionInfo> GetHandlerForEvent(string eventName);

        string GetEventKey<T>();
    }
}
