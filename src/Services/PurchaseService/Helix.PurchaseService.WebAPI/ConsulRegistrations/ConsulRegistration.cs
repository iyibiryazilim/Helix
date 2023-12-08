using Consul;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace Helix.PurchaseService.WebAPI.ConsulRegistrations;

public static class ConsulRegistration
{
	public static IServiceCollection ConfigureConsul(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSingleton<IConsulClient, ConsulClient>(x => new ConsulClient(consulConfig =>
		{
			var address = configuration["ConsulConfig:Address"];
			consulConfig.Address = new Uri(address);
		}));

		return services;
	}

	public static WebApplication RegisterWithConsul(this WebApplication app, IHostApplicationLifetime lifetime)
	{
		var consulClient = app.Services.GetRequiredService<IConsulClient>();
		var service = app.Services.GetService<IServer>();
		var addresses = service.Features.Get<IServerAddressesFeature>();

		//var features = app.Services. Properties["server.Features"] as FeatureCollection;
		//var addresses = features.Get<IServerAddressesFeature>();
		if (addresses.Addresses.Count==0)
		{
			addresses.Addresses.Add("http://localhost:5173");
		}
		var address= addresses.Addresses.First();

		var uri = new Uri(address);

		var register = new AgentServiceRegistration()
		{
			ID = "PurchaseService",
			Name = "PurchaseService",
			Address = $"{uri.Host}",
			Port = uri.Port,
			Tags = new[] { "PurchaseService", "Purchase" }
		};

		consulClient.Agent.ServiceDeregister(register.ID).Wait();
		consulClient.Agent.ServiceRegister(register).Wait();

		lifetime.ApplicationStopping.Register(() =>
		{
			//logger deregister
			consulClient.Agent.ServiceDeregister(register.ID).Wait();
		});

		return app;
	}
}
