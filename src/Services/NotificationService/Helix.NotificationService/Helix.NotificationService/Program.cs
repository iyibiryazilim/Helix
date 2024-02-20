using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.NotificationService;
using Helix.NotificationService.AuthRegistrations;
using Helix.NotificationService.Events;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
 // Register Worker as a hosted service
builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<LOGOSuccessIntegrationEventHandler>();
builder.Services.AddTransient<LOGOFailureIntegrationEventHandler>();
builder.Services.AddTransient<SYSMessageIntegrationEventHandler>();

// Register the event bus factory and create an instance of IEventBus
builder.Services.AddSingleton<IEventBus>(serviceProvider =>
{
	var eventBus = EventBusFactory.Create(new Helix.EventBus.Base.EventBusConfig
	{
		ConnectionRetryCount = 5,
		SubscriperClientAppName = "LBSService",
		DefaultTopicName = "HelixTopicName",
		EventBusType = EventBusType.RabbitMQ,
		EventNameSuffix = nameof(IntegrationEvent),
	}, serviceProvider);

	// Subscribe to events here if necessary 
	eventBus.Subscribe<LOGOSuccessIntegrationEvent, LOGOSuccessIntegrationEventHandler>();
	eventBus.Subscribe<LOGOFailureIntegrationEvent, LOGOFailureIntegrationEventHandler>();
	eventBus.Subscribe<SYSMessageIntegrationEvent, SYSMessageIntegrationEventHandler>();
	return eventBus;
});

builder.Services.ConfigureAuth(builder.Configuration);

var host = builder.Build();
host.UseAuthorization();
host.Run();
