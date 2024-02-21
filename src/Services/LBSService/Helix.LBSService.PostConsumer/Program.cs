using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.LBSService.PostConsumer;
using Helix.LBSService.PostConsumer.Events;
using Helix.LBSService.PostConsumer.Helper;

var builder = Host.CreateApplicationBuilder(args);
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
builder.Services.AddSingleton<IHttpClientService, HttpClientService>(); 

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


	return eventBus;
});
var host = builder.Build();
host.Run();
