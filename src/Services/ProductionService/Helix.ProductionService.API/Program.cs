using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Infrastructure.Repository;
using Helix.ProductionService.WebAPI.ConsulRegistrations;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddTransient<IWorkOrderService, WorkOrderDataStore>();
builder.Services.AddTransient<IWorkstationService, WorkstationDataStore>();
builder.Services.AddTransient<IStopCauseService, StopCauseDataStore>();
builder.Services.AddTransient<IStopTransactionService, StopTransactionDataStore>();
builder.Services.AddTransient<IProductionOrderService, ProductionOrderDataStore>();
builder.Services.AddTransient<IProductionTransactionLineService, ProductionTransactionLineDataStore>();
builder.Services.AddTransient<IProductionTransactionService, ProductionTransactionDataStore>();
builder.Services.AddTransient<IProductService, ProductBaseDataStore>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.RegisterWithConsul(app.Lifetime);

app.Run();
