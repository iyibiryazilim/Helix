using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Infrastructure.EventHandlers;
using Helix.SalesService.Infrastructure.Repository;
using Helix.SalesService.WebAPI.ConsulRegistrations;
using Helix.Tiger.DataAccess.DataStores;
using RabbitMQ.Client;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddSingleton<IEventBus>(eb =>
{
	return EventBusFactory.Create(new Helix.EventBus.Base.EventBusConfig
	{
		ConnectionRetryCount = 5,
		SubscriperClientAppName = "SalesService",
		DefaultTopicName = "HelixTopicName",
		EventBusType = EventBusType.RabbitMQ,
		EventNameSuffix = nameof(IntegrationEvent),
		//Connection = new ConnectionFactory
		//{
		//	HostName = "rattlesnake-01.rmq.cloudamqp.com",
		//	Port = 5672,
		//	UserName = "oqhbtvgt",
		//	Password = "Zh4cCLQdL1U3_E5dtAA0TOh7vnYUVA7g"
		//}
	}, eb);
});

var serviceProvider = builder.Services.BuildServiceProvider();

var eventBus = serviceProvider.GetRequiredService<IEventBus>();

eventBus.Subscribe<SalesOrderInsertedIntegrationEvent, SalesOrderInsertedIntegrationEventHandler>();
eventBus.Subscribe<RetailSalesDispatchTransactionInsertedIntegrationEvent, RetailSalesDispatchTransactionInsertedIntegrationEventHandler>();
eventBus.Subscribe<RetailSalesReturnDispatchTransactionInsertedIntegrationEvent, RetailSalesReturnDispatchTransactionInsertedIntegrationEventHandler>();
eventBus.Subscribe<WholeSalesDispatchTransactionInsertedIntegrationEvent, WholeSalesDispatchTransactionInsertedIntegrationEventHandler>();
eventBus.Subscribe<WholeSalesReturnDispatchTransactionInsertedIntegrationEvent, WholeSalesReturnDispatchTransactionInsertedIntegrationEventHandler>();



//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.RegisterWithConsul(app.Lifetime);

app.UseSerilogRequestLogging();

app.Run();
