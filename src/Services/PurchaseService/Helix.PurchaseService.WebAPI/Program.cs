using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Base;
using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Infrastructure.Repository;
using Helix.PurchaseService.WebAPI.ConsulRegistrations;
using Helix.Tiger.DataAccess.DataStores;
using Serilog;
using Helix.EventBus.Factory;
using Helix.PurchaseService.Domain.Events;
using Helix.PurchaseService.Infrastructure.EventHandlers;
using Helix.PurchaseService.WebAPI.AuthRegistrations;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog();

builder.Services.ConfigureAuth(builder.Configuration);

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

eventBus.Subscribe<PurchaseOrderInsertedIntegrationEvent, PurchaseOrderInsertedIntegrationEventHandler>();
eventBus.Subscribe<PurchaseDispatchTransactionInsertedIntegrationEvent, PurchaseDispatchTransactionInsertedIntegrationEventHandler>();
eventBus.Subscribe<PurchaseReturnDispatchTransactionInsertedIntegrationEvent, PurchaseReturnDispatchTransactionInsertedIntegrationEventHandler>();

// Add services to the container.
builder.Services.ConfigureConsul(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IPurchaseOrderLineService, PurchaseOrderLineDataStore>();
builder.Services.AddTransient<IPurchaseOrderService, PurchaseOrderDataStore>();
builder.Services.AddTransient<IPurchaseDispatchTransactionLineService, PurchaseDispatchTransactionLineDataStore>();
builder.Services.AddTransient<IPurchaseDispatchTransactionService, PurchaseDispatchTransactionDataStore>();
builder.Services.AddTransient<IPurchaseReturnDispatchTransactionLineService, PurchaseReturnDispatchTransactionLineDataStore>();
builder.Services.AddTransient<IPurchaseReturnDispatchTransactionService, PurchaseReturnDispatchTransactionDataStore>();
builder.Services.AddTransient<ISupplierService, SupplierDataStore>();
builder.Services.AddTransient<ISupplierTransactionService, SupplierTransactionDataStore>();
builder.Services.AddTransient<ISupplierTransactionLineService, SupplierTransactionLineDataStore>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
 app.MapControllers();
 
app.Run();
