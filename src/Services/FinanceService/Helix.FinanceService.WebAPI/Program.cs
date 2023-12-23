using Helix.FinanceService.Application.Services;
using Helix.FinanceService.Infrastructure.Repository;
using Helix.FinanceService.WebAPI.AuthRegistrations;
using Helix.FinanceService.WebAPI.ConsulRegistrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddTransient<ICustomerService, CustomerDataStore>();

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
