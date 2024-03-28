using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.LBSNotification.Events;
using Helix.LBSNotification.Helpers.AuthenticationHelper;
using Helix.LBSNotification.Helpers.HttpClientHelper;
using Helix.NotificationService;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Helix LBS Notification";
});

builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<SYSMessageIntegrationEventHandler>();
builder.Services.AddSingleton<IHttpClientService, HttpClientService>();
builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
// Register Worker as a hosted service


LoggerProviderOptions.RegisterProviderOptions<
    EventLogSettings, EventLogLoggerProvider>(builder.Services);

//On docker gonna be comment
builder.Logging.AddEventLog(eventLogSettings =>
{
    eventLogSettings.LogName = "Application";
    eventLogSettings.SourceName = "Helix.NotificationService";
});


// Register the event bus factory and create an instance of IEventBus
builder.Services.AddSingleton<IEventBus>(serviceProvider =>
{
    var eventBus = EventBusFactory.Create(new Helix.EventBus.Base.EventBusConfig
    {
        ConnectionRetryCount = 5,
        SubscriperClientAppName = "LBSService",
        DefaultTopicName = "HelixTopicName",
        EventBusType = EventBusType.RabbitMQ,
        EventBusConnectionString = configuration.GetSection("RabbitMQ")["RabbitMQConnectionString"],
        EventNameSuffix = nameof(IntegrationEvent),
    }, serviceProvider);

    eventBus.Subscribe<SYSMessageIntegrationEvent, SYSMessageIntegrationEventHandler>();
   

    return eventBus;
});
var host = builder.Build();
host.Run();