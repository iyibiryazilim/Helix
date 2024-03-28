using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.LBSNotification;
using Helix.LBSNotification.Events;
using Helix.LBSNotification.Helpers.HttpClientHelper;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
// Register Worker as a hosted service
builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<SysMessageIntegrationEventHandler>();
builder.Services.AddSingleton<IHttpClientService, HttpClientService>();

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
    eventBus.Subscribe<SysMessageIntegrationEvent, SysMessageIntegrationEventHandler>();
    return eventBus;
});


var host = builder.Build();
host.Run();
