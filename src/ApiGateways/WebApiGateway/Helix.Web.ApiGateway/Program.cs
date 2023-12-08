using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
		config
		.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
		.AddJsonFile("appsettings.json", true, true)
		.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
		.AddJsonFile("Configurations\\ocelot.json")
		.AddEnvironmentVariables();
})
			.ConfigureServices(s =>
			{
				s.AddOcelot().AddConsul();
			});
//builder.Configuration.AddJsonFile(builder.Host.c "/Configuration/ocelot.json",false,true).AddEnvironmentVariables();
//builder.Services.AddOcelot();
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

await app.UseOcelot();

app.Run();
