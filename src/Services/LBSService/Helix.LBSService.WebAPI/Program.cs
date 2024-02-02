using Helix.LBSService.Go.DataStores;
using Helix.LBSService.Go.Services;
using Helix.LBSService.Tiger.DataStores;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.Helper;
using Helix.LBSService.WebAPI.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


builder.Services.AddControllers();

builder.Configuration.AddJsonFile("appsettings.json");
 

LBSParameterModel parameterModel = builder.Configuration.GetSection(nameof(LBSParameter)).Get<LBSParameterModel>();
LBSParameter.FirmNumber = parameterModel.FirmNumber;
LBSParameter.IsTiger = parameterModel.IsTiger;
LBSParameter.Username = parameterModel.Username;
LBSParameter.Password = parameterModel.Password;
LBSParameter.DB_DataSource = parameterModel.DB_DataSource;
LBSParameter.DB_InitialCatalog = parameterModel.DB_InitialCatalog;
LBSParameter.DB_UserId = parameterModel.DB_UserId;
LBSParameter.DB_Password = parameterModel.DB_Password;

Debug.WriteLine(LBSParameter.Connection);

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

app.Run();
