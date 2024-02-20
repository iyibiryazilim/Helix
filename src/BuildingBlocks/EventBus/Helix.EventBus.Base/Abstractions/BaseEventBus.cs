using Helix.EventBus.Base.Events;
using Helix.EventBus.Base.SubManagers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Helix.EventBus.Base.Abstractions;

public abstract class BaseEventBus : IEventBus
{
    public readonly IServiceProvider _serviceProvider;
    public readonly IEventBusSubscriptionManager _subscriptionManager;

    public EventBusConfig _eventBusconfig;

    public BaseEventBus(IServiceProvider serviceProvider, EventBusConfig eventBusconfig)
    {
        _serviceProvider = serviceProvider;
        _subscriptionManager = new InMemoryEventBusSubscriptionManager(ProcessEventName);
        _eventBusconfig = eventBusconfig;
    }
    public virtual string ProcessEventName(string eventName)
    {
        if (_eventBusconfig.DeleteEventPrefix)
            eventName = eventName.TrimStart(_eventBusconfig.EventNamePrefix.ToArray());

        if(_eventBusconfig.DeleteEventSuffix)
        { 
			// Check if eventName ends with the suffix
			if (eventName.EndsWith(_eventBusconfig.EventNameSuffix))
			{
				// Remove the suffix
				eventName = eventName.Substring(0, eventName.Length - _eventBusconfig.EventNameSuffix.Length);
			}
		}
 
        return eventName;
    }
    public virtual string GetSubName(string eventName)
    {
        return $"{_eventBusconfig.SubscriperClientAppName}.{ProcessEventName(eventName)}";
    }
    public virtual void Dispose()
    {
        _eventBusconfig = null;
    }
    public async Task<bool> ProcessEvent(string eventName,string message)
    {
        eventName  = ProcessEventName(eventName);

        var processed = false;

        if (_subscriptionManager.HasSubscriptionsForEvent(eventName))
        {
            var subscriptions= _subscriptionManager.GetHandlerForEvent(eventName);

            using (var scope = _serviceProvider.CreateScope())
            {
                foreach (var subscription in subscriptions)
                {
                    var handler = _serviceProvider.GetService(subscription.HandleType);

                    if (handler == null)
                    {
                        Console.WriteLine("Handler is null");
						continue;
					}

                    var eventType = _subscriptionManager.GetEventTypeByName($"{_eventBusconfig.EventNamePrefix}{eventName}{_eventBusconfig.EventNameSuffix}");

                    var integrationEvent = JsonConvert.DeserializeObject(message,eventType);

                    var concreateType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                    await (Task)concreateType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent });
                }
            }

            processed = true;

        }

        return processed;
    }
	public abstract void Publish(IntegrationEvent @event);
    public abstract void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
    public abstract void UnSubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
    public abstract void Consume(IntegrationEvent @event);
    public abstract EventingBasicConsumer GetConsumer();
    public abstract IModel GetConsumerChannel();

}
