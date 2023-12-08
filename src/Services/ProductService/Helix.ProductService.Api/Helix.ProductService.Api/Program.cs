using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddTransient<ICommercialProductService, CommercialProductDataStore>();
builder.Services.AddTransient<IEndProductService, EndProductDataStore>();
builder.Services.AddTransient<IFixedAssetProductService, FixedAssetProductDataStore>();
builder.Services.AddTransient<ISemiProductService,SemiProductDataStore>();
builder.Services.AddTransient<IRawProductService, RawProductDataStore>();
builder.Services.AddTransient<IWarehouseService, WarehouseDataStore>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


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
