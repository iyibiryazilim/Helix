using Helix.EventBus.Base.Events;

namespace Helix.EventBus.Base;

public class EventBusConfig
{
	public int ConnectionRetryCount { get; set; } = 30;
	public string DefaultTopicName { get; set; } = "HelixEventBus";
	public string EventBusConnectionString { get; set; } = string.Empty;
	public string SubscriperClientAppName { get; set; } = string.Empty;
	public string EventNamePrefix { get; set; } = string.Empty;
	public string EventNameSuffix { get; set; } = nameof(IntegrationEvent);
	public EventBusType EventBusType { get; set; } = EventBusType.RabbitMQ;
	public object Connection { get; set; }

	public bool DeleteEventPrefix => !string.IsNullOrEmpty(EventNamePrefix);
	public bool DeleteEventSuffix => !string.IsNullOrEmpty(EventNameSuffix);
}

public enum EventBusType
{
	RabbitMQ = 0,
	AzureBusService = 1
}