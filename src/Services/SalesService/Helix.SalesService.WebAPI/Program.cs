using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Infrastructure.EventHandlers;
using Helix.SalesService.Infrastructure.Repository;
using Helix.Tiger.DataAccess.DataStores;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureAuth(builder.Configuration);

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddSingleton<IEventBus>(eb =>
{
	return EventBusFactory.Create(new Helix.EventBus.Base.EventBusConfig
	{
		ConnectionRetryCount = 5,
		SubscriperClientAppName = "LBSService",
		DefaultTopicName = "HelixTopicName",
		EventBusType = EventBusType.RabbitMQ,
		EventBusConnectionString = configuration.GetSection("RabbitMQ")["RabbitMQConnectionString"],
		EventNameSuffix = nameof(IntegrationEvent),
	}, eb);
});

var serviceProvider = builder.Services.BuildServiceProvider();

var eventBus = serviceProvider.GetRequiredService<IEventBus>();

eventBus.Subscribe<SalesOrderInsertingIntegrationEvent, SalesOrderInsertingIntegrationEventHandler>();
eventBus.Subscribe<RetailSalesDispatchTransactionInsertingIntegrationEvent, RetailSalesDispatchTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<RetailSalesReturnDispatchTransactionInsertingIntegrationEvent, RetailSalesReturnDispatchTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<WholeSalesDispatchTransactionInsertingIntegrationEvent, WholeSalesDispatchTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<WholeSalesReturnDispatchTransactionInsertingIntegrationEvent, WholeSalesReturnDispatchTransactionInsertingIntegrationEventHandler>();

//builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddTransient<IRetailSalesDispatchTransactionService, RetailSalesDispatchTransactionDataStore>();
builder.Services.AddTransient<IRetailSalesDispatchTransactionLineService, RetailSalesDispatchTransactionLineDataStore>();
builder.Services.AddTransient<IRetailSalesReturnDispatchTransactionLineService, RetailSalesReturnDispatchTransactionLineDataStore>();
builder.Services.AddTransient<IRetailSalesReturnDispatchTransactionService, RetailSalesReturnDispatchTransactionDataStore>();
builder.Services.AddTransient<IWholeSalesDispatchTransactionLineService, WholeSalesDispatchTransactionLineDataStore>();
builder.Services.AddTransient<IWholeSalesDispatchTransactionService, WholeSalesDispatchTransactionDataStore>();
builder.Services.AddTransient<IWholeSalesReturnDispatchTransactionLineService, WholeSalesReturnDispatchTransactionLineDataStore>();
builder.Services.AddTransient<IWholeSalesReturnDispatchTransactionService, WholeSalesReturnDispatchTransactionDataStore>();
builder.Services.AddTransient<ISalesOrderService, SalesOrderDataStore>();
builder.Services.AddTransient<ICustomerTransactionLineService, CustomerTransactionLineDataStore>();
builder.Services.AddTransient<ICustomerTransactionService, CustomerTransactionDataStore>();
builder.Services.AddTransient<ISalesOrderLineService, SalesOrderLineDataStore>();
builder.Services.AddTransient<IDriverService, DriverDataStore>();
builder.Services.AddTransient<ICarrierService, CarrierDataStore>();
builder.Services.AddTransient<ISpeCodeModelService, SpeCodeDataStore>();
builder.Services.AddTransient<IShipInfoService, ShipInfoDataStore>();

builder.Services.AddTransient<ICustomerService, CustomerDataStore>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.RegisterWithConsul(app.Lifetime);

app.UseSerilogRequestLogging();

app.Run();