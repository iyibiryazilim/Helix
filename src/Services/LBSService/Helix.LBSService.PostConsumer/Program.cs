using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.LBSService.PostConsumer;
using Helix.LBSService.PostConsumer.Events;
using Helix.LBSService.PostConsumer.Helper;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
	options.ServiceName = "Helix Post Consumer";
});
builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<ConsumableTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<InCountingTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<OutCountingTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<ProductionTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<PurchaseDispatchTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<PurchaseReturnDispatchTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<RetailSalesDispatchTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<RetailSalesReturnDispatchTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<TransferTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<WastageTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<WholeSalesDispatchTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<WholeSalesReturnDispatchTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<CustomerInsertingIntegrationEventHandler>();
builder.Services.AddTransient<SalesOrderInsertingIntegrationEventHandler>();
builder.Services.AddTransient<PurchaseOrderInsertingIntegrationEventHandler>();
builder.Services.AddSingleton<IHttpClientService, HttpClientService>();
builder.Services.AddTransient<WorkOrderChangeStatusInsertedIntegrationEventHandler>();
builder.Services.AddTransient<StopTransactionForWorkOrderInsertedIntegrationEventHandler>();
builder.Services.AddTransient<VariantInsertingIntegrationEventHandler>();
builder.Services.AddTransient<OutSourceWorkOrderChangeStatusInsertedIntegrationEventHandler>();
builder.Services.AddTransient<OutSourceWorkOrderInsertActualQuantityIntegrationEventHandler>();
builder.Services.AddTransient<OutSourceWorkOrderStopTransactionInsertingIntegrationEventHandler>();
builder.Services.AddTransient<WorkOrderInsertActualQuantityIntegrationEventHandler>();
builder.Services.AddTransient<WorkOrderStopTransactionInsertingIntegrationEventHandler>();

LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(builder.Services);

//On docker gonna be comment
builder.Logging.AddEventLog(eventLogSettings =>
{
	eventLogSettings.LogName = "Application";
	eventLogSettings.SourceName = "Helix.PostConsumer";
});
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
var test = configuration.GetSection("RabbitMQ")["RabbitMQConnectionString"];
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

	eventBus.Subscribe<ConsumableTransactionInsertingIntegrationEvent, ConsumableTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<InCountingTransactionInsertingIntegrationEvent, InCountingTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<OutCountingTransactionInsertingIntegrationEvent, OutCountingTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<ProductionTransactionInsertingIntegrationEvent, ProductionTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<PurchaseDispatchTransactionInsertingIntegrationEvent, PurchaseDispatchTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<PurchaseReturnDispatchTransactionInsertingIntegrationEvent, PurchaseReturnDispatchTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<RetailSalesDispatchTransactionInsertingIntegrationEvent, RetailSalesDispatchTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<RetailSalesReturnDispatchTransactionInsertingIntegrationEvent, RetailSalesReturnDispatchTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<TransferTransactionInsertingIntegrationEvent, TransferTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<WastageTransactionInsertingIntegrationEvent, WastageTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<WholeSalesDispatchTransactionInsertingIntegrationEvent, WholeSalesDispatchTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<WholeSalesReturnDispatchTransactionInsertingIntegrationEvent, WholeSalesReturnDispatchTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<WorkOrderChangeStatusInsertedIntegrationEvent, WorkOrderChangeStatusInsertedIntegrationEventHandler>();
	eventBus.Subscribe<PurchaseOrderInsertingIntegrationEvent, PurchaseOrderInsertingIntegrationEventHandler>();
	eventBus.Subscribe<SalesOrderInsertingIntegrationEvent, SalesOrderInsertingIntegrationEventHandler>();
	eventBus.Subscribe<StopTransactionForWorkOrderInsertedIntegrationEvent, StopTransactionForWorkOrderInsertedIntegrationEventHandler>();
	eventBus.Subscribe<CustomerInsertingIntegrationEvent, CustomerInsertingIntegrationEventHandler>();
	eventBus.Subscribe<VariantInsertingIntegrationEvent, VariantInsertingIntegrationEventHandler>();
	eventBus.Subscribe<OutSourceWorkOrderChangeStatusInsertedIntegrationEvent, OutSourceWorkOrderChangeStatusInsertedIntegrationEventHandler>();
	eventBus.Subscribe<OutSourceWorkOrderInsertActualQuantityIntegrationEvent, OutSourceWorkOrderInsertActualQuantityIntegrationEventHandler>();
	eventBus.Subscribe<OutSourceWorkOrderStopTransactionInsertingIntegrationEvent, OutSourceWorkOrderStopTransactionInsertingIntegrationEventHandler>();
	eventBus.Subscribe<WorkOrderInsertActualQuantityIntegrationEvent, WorkOrderInsertActualQuantityIntegrationEventHandler>();
	eventBus.Subscribe<WorkOrderStopTransactionInsertingIntegrationEvent, WorkOrderStopTransactionInsertingIntegrationEventHandler>();

	return eventBus;
});
var host = builder.Build();
host.Run();