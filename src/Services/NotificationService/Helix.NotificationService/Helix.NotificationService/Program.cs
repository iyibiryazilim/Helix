using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.NotificationService;
using Helix.NotificationService.Events;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();


builder.Services.AddSingleton<IEventBus>(eb =>
{
	return EventBusFactory.Create(new Helix.EventBus.Base.EventBusConfig
	{
		ConnectionRetryCount = 5,
		SubscriperClientAppName = "LBSService",
		DefaultTopicName = "HelixTopicName",
		EventBusType = EventBusType.RabbitMQ,
		EventNameSuffix = nameof(IntegrationEvent),
 
	}, eb);
});
var serviceProvider = builder.Services.BuildServiceProvider();

var eventBus = serviceProvider.GetRequiredService<IEventBus>();

eventBus.Subscribe<LOGOSuccessIntegrationEvent, LOGOSuccessIntegrationEventHandler>();
eventBus.Subscribe<LOGOFailureIntegrationEvent, LOGOFailureIntegrationEventHandler>();
eventBus.Subscribe<SYSMessageIntegrationEvent, SYSMessageIntegrationEventHandler>();

 var host = builder.Build();
host.Run();
