using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Infrastructure.Repository;
using Helix.PurchaseService.WebAPI.ConsulRegistrations;
using Helix.Tiger.DataAccess.DataStores;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


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
