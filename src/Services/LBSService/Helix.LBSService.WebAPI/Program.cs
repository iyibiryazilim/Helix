using Helix.LBSService.WebAPI.DataStores;
using Helix.LBSService.WebAPI.Helper;
using Helix.LBSService.WebAPI.Models;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUnityApplicationService, UnityApplicationDataStore>();

builder.Services.AddTransient<ILG_WorkOrderService, LG_WorkOrderDataStore>();
builder.Services.AddTransient<ILG_ProductionTransactionService, LG_ProductionTransactionDataStore>();

builder.Services.AddControllers();

builder.Configuration.AddJsonFile("appsettings.json");
 

LBSParameterModel parameterModel = builder.Configuration.GetSection(nameof(LBSParameter)).Get<LBSParameterModel>();
LBSParameter.FirmNumber = parameterModel.FirmNumber;
LBSParameter.IsTiger = parameterModel.IsTiger;
LBSParameter.Username = parameterModel.Username;
LBSParameter.Password = parameterModel.Password;

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
