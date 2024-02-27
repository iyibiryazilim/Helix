using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.NotificationService;
using Helix.NotificationService.Events;
using Helix.NotificationService.Helper;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
  // Register Worker as a hosted service
builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<LOGOSuccessIntegrationEventHandler>();
builder.Services.AddTransient<LOGOFailureIntegrationEventHandler>();
builder.Services.AddTransient<SYSMessageIntegrationEventHandler>();
builder.Services.AddSingleton<IHttpClientService, HttpClientService>(); 
builder.Services.AddSingleton<IAuthenticationService, AuthenticateService>();

// Register the event bus factory and create an instance of IEventBus
builder.Services.AddSingleton<IEventBus>(serviceProvider =>
{
	var eventBus = EventBusFactory.Create(new Helix.EventBus.Base.EventBusConfig
	{
		ConnectionRetryCount = 5,
		SubscriperClientAppName = "LBSService",
		DefaultTopicName = "HelixTopicName",
		EventBusType = EventBusType.RabbitMQ,
		//EventBusConnectionString = "amqp://guest:guest@rabbit.management:5672", 
		EventNameSuffix = nameof(IntegrationEvent),
	}, serviceProvider);

	// Subscribe to events here if necessary 
	eventBus.Subscribe<LOGOSuccessIntegrationEvent, LOGOSuccessIntegrationEventHandler>();
	eventBus.Subscribe<LOGOFailureIntegrationEvent, LOGOFailureIntegrationEventHandler>();
	eventBus.Subscribe<SYSMessageIntegrationEvent, SYSMessageIntegrationEventHandler>();
	return eventBus;
});

  
var host = builder.Build();
 host.Run();
