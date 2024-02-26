using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.ProductService.Api.AuthRegistrations;
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Events;
using Helix.ProductService.Infrastructure.EventHandlers;
using Helix.ProductService.Infrastructure.Repository;
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
		EventBusConnectionString = "amqp://guest:guest@rabbit.management:5672", 
		EventNameSuffix = nameof(IntegrationEvent),
        
    }, eb);
});

var serviceProvider = builder.Services.BuildServiceProvider();

var eventBus = serviceProvider.GetRequiredService<IEventBus>();

eventBus.Subscribe<ConsumableTransactionInsertingIntegrationEvent, ConsumableTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<InCountingTransactionInsertingIntegrationEvent, InCountingTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<ProductionTransactionInsertingIntegrationEvent, ProductionTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<TransferTransactionInsertingIntegrationEvent, TransferTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<WastageTransactionInsertingIntegrationEvent, WastageTransactionInsertingIntegrationEventHandler>();
eventBus.Subscribe<OutCountingTransactionInsertingIntegrationEvent, OutCountingTransactionInsertingIntegrationEventHandler>();





//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

//// Add services to the container.
//builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddTransient<ICommercialProductService, CommercialProductDataStore>();
builder.Services.AddTransient<IEndProductService, EndProductDataStore>();
builder.Services.AddTransient<IFixedAssetProductService, FixedAssetProductDataStore>();
builder.Services.AddTransient<ISemiProductService,SemiProductDataStore>();
builder.Services.AddTransient<IRawProductService, RawProductDataStore>();
builder.Services.AddTransient<IWarehouseService, WarehouseDataStore>();
builder.Services.AddTransient<IConsumableTransactionService, ConsumableTransactionDataStore>();
builder.Services.AddTransient<IConsumableTransactionLineService,ConsumableTransactionLineDataStore>();
builder.Services.AddTransient<IInCountingTransactionService, InCountingTransactionDataStore>();
builder.Services.AddTransient<IInCountingTransactionLineService, InCountingTransactionLineDataStore>();
builder.Services.AddTransient<IOutCountingTransactionService, OutCountingTransactionDataStore>();
builder.Services.AddTransient<IOutCountingTransactionLineService, OutCountingTransactionLineDataStore>();
builder.Services.AddTransient<IProductionTransactionService, ProductionTransactionDataStore>();
builder.Services.AddTransient<IProductionTransactionLineService, ProductionTransactionLineDataStore>();
builder.Services.AddTransient<ITransferTransactionService, TransferTransactionDataStore>();
builder.Services.AddTransient<ITransferTransactionLineService, TransferTransactionLineDataStore>();
builder.Services.AddTransient<IWastageTransactionService, WastageTransactionDataStore>();
builder.Services.AddTransient<IWastageTransactionLineService, WastageTransactionLineDataStore>();
builder.Services.AddTransient<ISubUnitsetService, SubUnitsetDataStore>();
builder.Services.AddTransient<IUnitsetService, UnitsetDataStore>();
builder.Services.AddTransient<IProductService, ProductDataStore>();
builder.Services.AddTransient<IProductTransactionLineService, ProductTransactionLineDataStore>();
builder.Services.AddTransient<IWarehouseTransactionService, WarehouseTransactionDataStore>();
builder.Services.AddTransient<IWarehouseTotalService, WarehouseTotalDataStore>();
builder.Services.AddTransient<IWarehouseParameterService, WarehouseParameterDataStore>();










builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseAuthentication();

app.MapControllers();
//app.RegisterWithConsul(app.Lifetime);
app.UseSerilogRequestLogging();

app.Run();
