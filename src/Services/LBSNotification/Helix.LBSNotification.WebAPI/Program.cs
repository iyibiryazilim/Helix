using Helix.LBSNotification.WebAPI.DataStore;
using Helix.LBSNotification.WebAPI.Models;
using Helix.LBSNotification.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<NotificationDatabaseSettings>(
    builder.Configuration.GetSection("NotificationDatabase"));

builder.Services.AddSingleton<INotificationResultService, MongoDBDataStore>();


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

app.Run();
