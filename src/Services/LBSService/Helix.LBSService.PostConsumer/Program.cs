using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.LBSService.PostConsumer;
using Helix.LBSService.PostConsumer.Events;
using Helix.LBSService.PostConsumer.Helper;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<ConsumableTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<InCountingTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<OutCountingTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<ProductionTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<PurchaseDispatchTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<PurchaseReturnDispatchTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<RetailSalesDispatchTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<RetailSalesReturnDispatchTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<TransferTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<WastageTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<WholeSalesDispatchTransactionInsertedIntegrationEventHandler>();
builder.Services.AddTransient<WholeSalesReturnDispatchTransactionInsertedIntegrationEventHandler>();
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

 	eventBus.Subscribe<ConsumableTransactionInsertedIntegrationEvent, ConsumableTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<InCountingTransactionInsertedIntegrationEvent, InCountingTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<OutCountingTransactionInsertedIntegrationEvent, OutCountingTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<ProductionTransactionInsertedIntegrationEvent, ProductionTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<PurchaseDispatchTransactionInsertedIntegrationEvent, PurchaseDispatchTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<PurchaseReturnDispatchTransactionInsertedIntegrationEvent, PurchaseReturnDispatchTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<RetailSalesDispatchTransactionInsertedIntegrationEvent, RetailSalesDispatchTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<RetailSalesReturnDispatchTransactionInsertedIntegrationEvent, RetailSalesReturnDispatchTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<TransferTransactionInsertedIntegrationEvent, TransferTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<WastageTransactionInsertedIntegrationEvent, WastageTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<WholeSalesDispatchTransactionInsertedIntegrationEvent, WholeSalesDispatchTransactionInsertedIntegrationEventHandler>();
	eventBus.Subscribe<WholeSalesReturnDispatchTransactionInsertedIntegrationEvent, WholeSalesReturnDispatchTransactionInsertedIntegrationEventHandler>(); 


	return eventBus;
});
var host = builder.Build();
host.Run();
