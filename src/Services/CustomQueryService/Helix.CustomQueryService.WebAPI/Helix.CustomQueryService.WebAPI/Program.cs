using Helix.CustomQueryService.WebAPI.DataStores;
using Helix.CustomQueryService.WebAPI.Models;
using Helix.CustomQueryService.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
IConfigurationSection obj = builder.Configuration.GetSection(nameof(LBSParameter));
LBSParameter? _parameter = obj.Get<LBSParameter>();
// Add services to the container.
builder.Services.AddTransient<ICustomQueryService>(x => new CustomQueryDataStore(_parameter));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
