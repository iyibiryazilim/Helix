using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Events;
using Helix.ProductionService.Infrastructure.EventHandlers;
using Helix.ProductionService.Infrastructure.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.ConfigureAuth(builder.Configuration);
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
		EventNameSuffix = nameof(IntegrationEvent)
	}, eb);
});

var serviceProvider = builder.Services.BuildServiceProvider();
var eventBus = serviceProvider.GetRequiredService<IEventBus>();

eventBus.Subscribe<OutSourceWorkOrderInsertActualQuantityIntegrationEvent, OutSourceWorkOrderInsertActualQuantityIntegrationEventHandler>();
eventBus.Subscribe<OutSourceWorkOrderStopTransactionInsertingIntegrationEvent, OutSourceWorkOrderStopTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<OutSourceWorkOrderChangeStatusInsertedIntegrationEvent, OutSourceWorkOrderChangeStatusInsertedIntegrationEventHandler>();
eventBus.Subscribe<WorkOrderInsertActualQuantityIntegrationEvent, WorkOrderInsertActualQuantityIntegrationEventHandler>();
eventBus.Subscribe<WorkOrderStopTransactionInsertingIntegrationEvent, WorkOrderStopTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<WorkOrderChangeStatusInsertedIntegrationEvent, WorkOrderChangeStatusInsertedIntegrationEventHandler>();
eventBus.Subscribe<WorkOrdersInsertedIntegrationEvent, WorkOrdersInsertedIntegrationEventHandler>();
eventBus.Subscribe<ProductionTransactionInsertedIntegrationEvent, ProductionTransactionInsertedIntegrationEventHandler>();
eventBus.Subscribe<ProductionTransactionLineInsertedIntegrationEvent, ProductionTransactionLineInsertedIntegrationEventHandler>();

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

// Add services to the container.
//builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddTransient<IWorkOrderService, WorkOrderDataStore>();
builder.Services.AddTransient<IWorkstationService, WorkstationDataStore>();
builder.Services.AddTransient<IStopCauseService, StopCauseDataStore>();
builder.Services.AddTransient<IStopTransactionService, StopTransactionDataStore>();
builder.Services.AddTransient<IProductionOrderService, ProductionOrderDataStore>();
builder.Services.AddTransient<IProductionTransactionLineService, ProductionTransactionLineDataStore>();
builder.Services.AddTransient<IProductionTransactionService, ProductionTransactionDataStore>();
builder.Services.AddTransient<IProductService, ProductBaseDataStore>();
builder.Services.AddTransient<IOutsourceProductionOrderService, OutsourceProductionOrderDataStore>();
builder.Services.AddTransient<IOutsourceWorkOrderService, OutsourceWorkOrderDataStore>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.RegisterWithConsul(app.Lifetime);
app.UseSerilogRequestLogging();

app.Run();