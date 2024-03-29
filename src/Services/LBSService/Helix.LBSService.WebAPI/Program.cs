using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.LBSService.Base.Events;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.DataStores;
using Helix.LBSService.Go.Services;
using Helix.LBSService.Tiger.DataStores;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DataStores;
using Helix.LBSService.WebAPI.Models;
using Helix.LBSService.WebAPI.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog();

LBSParameterModel parameterModel = builder.Configuration.GetSection(nameof(LBSParameter)).Get<LBSParameterModel>();
LBSParameter.FirmNumber = parameterModel.FirmNumber;
LBSParameter.IsTiger = parameterModel.IsTiger;
LBSParameter.Username = parameterModel.Username;
LBSParameter.Password = parameterModel.Password;
LBSParameter.Period = parameterModel.Period;
LBSParameter.Connection = configuration.GetConnectionString("LBSConnectionString");

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

eventBus.Subscribe<LOGOSuccessIntegrationEvent, LOGOSuccessIntegrationEventHandler>();
eventBus.Subscribe<LOGOFailureIntegrationEvent, LOGOFailureIntegrationEventHandler>();
eventBus.Subscribe<SYSMessageIntegrationEvent, SYSMessageIntegrationEventHandler>();

// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddTransient<IUnityApplicationService, UnityApplicationDataStore>();
builder.Services.AddTransient<ILG_WorkOrderService, LG_WorkOrderDataStore>();
builder.Services.AddTransient<ILG_ProductionTransactionService, LG_ProductionTransactionDataStore>();
builder.Services.AddTransient<ILG_InCountingTransactionService, LG_InCountingTransactionDataStore>();
builder.Services.AddTransient<ILG_OutCountingTransactionService, LG_OutCountingTransactionDataStore>();
builder.Services.AddTransient<ILG_ConsumableTransactionService, LG_ConsumableTransactionDataStore>();
builder.Services.AddTransient<ILG_TransferTransactionService, LG_TransferTransactionDataStore>();
builder.Services.AddTransient<ILG_RetailSalesDispatchTransactionService, LG_RetailSalesDispatchTransactionDataStore>();
builder.Services.AddTransient<ILG_RetailSalesReturnDispatchTransactionService, LG_RetailSalesReturnDispatchTransactionDataStore>();
builder.Services.AddTransient<ILG_WholeSalesReturnDispatchTransactionService, LG_WholeSalesReturnDispatchTransactionDataStore>();
builder.Services.AddTransient<ILG_WholeSalesDispatchTransactionService, LG_WholeSalesDispatchTransactionDataStore>();
builder.Services.AddTransient<ILG_PurchaseReturnDispatchTransactionService, LG_PurchaseReturnDispatchTransactionDataStore>();
builder.Services.AddTransient<ILG_PurchaseDispatchTransactionService, LG_PurchaseDispatchTransactionDataStore>();
builder.Services.AddTransient<ILG_WorkOrderService, LG_WorkOrderDataStore>();
builder.Services.AddTransient<ILG_WastageTransactionService, LG_WastageTransactionDataStore>();
builder.Services.AddTransient<ILG_STFICHE_Context, LG_STFICHE_Context>();
builder.Services.AddTransient<ILG_SalesOrderService, LG_SalesOrderDataStore>();
builder.Services.AddTransient<ILG_PurchaseOrderService, LG_PurchaseOrderDataStore>();
builder.Services.AddTransient<ILG_CurrentService, LG_CurrentDataStore>();
builder.Services.AddTransient<ILG_VariantService, LG_VariantDataStore>();
builder.Services.AddTransient<ILG_STLINE_Context, LG_STLINE_Context>();
builder.Services.AddTransient<ILG_EINVOICEDET_Context, LG_EINVOICEDET_Context>();
builder.Services.AddTransient<IL_LDOCNUM_Context, L_LDOCNUM_Context>();
builder.Services.AddTransient<ILG_SLTRANS_Context, LG_SLTRANS_Context>();
builder.Services.AddTransient<IProductionTransactionService, ProductionTransactionDataStore>();
builder.Services.AddTransient<IWastageTransactionService, WastageTransactionDataStore>();
builder.Services.AddTransient<IConsumableTransactionService, ConsumableTransactionDataStore>();
builder.Services.AddTransient<IRetailSalesDispatchTransactionService, RetailSalesDispatchTransactionDataStore>();
builder.Services.AddTransient<IRetailSalesReturnDispatchTransactionService, RetailSalesReturnDisatchTransactionDataStore>();
builder.Services.AddTransient<IWholeSalesReturnDispatchTransactionService, WholeSalesReturnDispatchTransactionDataStore>();
builder.Services.AddTransient<IWholeSalesDispatchTransactionService, WholeSalesDispatchTransactionDataStore>();
builder.Services.AddTransient<IPurchaseReturnDispatchTransactionService, PurchaseReturnDispatchTransactionDataStore>();
builder.Services.AddTransient<IPurchaseDispatchTransactionService, PurchaseDispatchTransactionDataStore>();
builder.Services.AddTransient<IInCountingTransactionService, InCountingTransactionDataStore>();
builder.Services.AddTransient<IOutCountingTransactionService, OutCountingTransactionDataStore>();
builder.Services.AddTransient<IPurchaseOrderService, PurchaseOrderDataStore>();
builder.Services.AddTransient<ISalesOrderService, SalesOrderDataStore>();
builder.Services.AddTransient<IWorkOrderService, WorkOrderDataStore>();
builder.Services.AddTransient<IDemandService, DemandDataStore>();
builder.Services.AddTransient<ILG_DemandService, LG_DemandDataStore>();
builder.Services.AddTransient<IVariantService, VariantDataStore>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
else
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSerilogRequestLogging();
app.Run();