using Helix.SalesService.Application.Repository;
using Helix.SalesService.Infrastructure.Repository;
using Helix.Tiger.DataAccess.DataStores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IRetailSalesDispatchTransactionService, RetailSalesDispatchTransactionDataStore>();
builder.Services.AddTransient<IRetailSalesDispatchTransactionLineService, RetailSalesDispatchTransactionLineDataStore>();

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

app.Run();
