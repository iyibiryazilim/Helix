using Helix.LBSService.EventConsumer.ProductTransaction;
using Helix.LBSService.EventConsumer.WorkOrder;
using Helix.LBSService.Tiger.DataStores;
using Helix.LBSService.Tiger.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

class Program
{
	static async Task Main(string[] args)
	{
		var builder = Host.CreateDefaultBuilder(args);
		IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

		Log.Logger = new LoggerConfiguration()
				   .ReadFrom.Configuration(configuration) 
				   .CreateLogger();

		Log.Logger.Information("starting rabbitmq console app...");

		builder.ConfigureServices((hostContext, services) =>
		{
			// Register services
			services.AddSingleton<IUnityApplicationService, UnityApplicationDataStore>(); 
			services.AddSingleton<ILG_WorkOrderService, LG_WorkOrderDataStore>();
			services.AddSingleton<ILG_WastageTransactionService, LG_WastageTransactionDataStore>();
			services.AddSingleton<ILG_InCountingTransactionService, LG_InCountingTransactionDataStore>();
			services.AddSingleton<ILG_OutCountingTransactionService, LG_OutCountingTransactionDataStore>();
			services.AddSingleton<ILG_ProductionTransactionService, LG_ProductionTransactionDataStore>();
			services.AddSingleton<ILG_ConsumableTransactionService, LG_ConsumableTransactionDataStore>();

			// Register consumers
			services.AddSingleton<WorkOrderStatusChangeConsumer>();
			services.AddSingleton<StopTransactionForWorkOrderConsumer>();
			services.AddSingleton<WastageTransactionConsumer>();
			services.AddSingleton<InCountingTransactionConsumer>();
			services.AddSingleton<OutCountingTransactionConsumer>();
			services.AddSingleton<ProductionTransactionConsumer>();
			services.AddSingleton<ConsumableTransactionConsumer>();



			// Add more consumers as needed
		});

		var host = builder.Build();

		using (var scope = host.Services.CreateScope())
		{
			var serviceProvider = scope.ServiceProvider;

			// Retrieve services
			var workOrderService = serviceProvider.GetRequiredService<ILG_WorkOrderService>();
			var wastageTransactionService = serviceProvider.GetRequiredService<ILG_WastageTransactionService>();
			var inCountingTransactionService = serviceProvider.GetRequiredService<ILG_InCountingTransactionService>();
			var outCountingTransactionService = serviceProvider.GetRequiredService<ILG_OutCountingTransactionService>();
			var productionTransactionService = serviceProvider.GetRequiredService<ILG_ProductionTransactionService>();
			var consumableTransactionService = serviceProvider.GetRequiredService<ILG_ConsumableTransactionService>(); 
			var unityApplicationService = serviceProvider.GetRequiredService<IUnityApplicationService>();

			// Log in with Unity
			Log.Debug("Unity is logging in");
			var loginResult = await unityApplicationService.LogIn();

			// Check the login result
			if (loginResult.IsSuccess)
			{
				Log.Information("Unity is logged in");
			}
			else
			{
				Log.Error(loginResult.Message);
			}

			var workOrderStatusChangeConsumer = serviceProvider.GetRequiredService<WorkOrderStatusChangeConsumer>();
			var stopTransactionForWorkOrderConsumer = serviceProvider.GetRequiredService<StopTransactionForWorkOrderConsumer>();
			var wastageTransactionConsumer = serviceProvider.GetRequiredService<WastageTransactionConsumer>();
			var consumableTransactionConsumer = serviceProvider.GetRequiredService<ConsumableTransactionConsumer>();
			var productionTransactionConsumer = serviceProvider.GetRequiredService<ProductionTransactionConsumer>();
			var inCountingTransactionConsumer = serviceProvider.GetRequiredService<InCountingTransactionConsumer>();
			var outCountingTransactionConsumer = serviceProvider.GetRequiredService<OutCountingTransactionConsumer>();


			await Task.WhenAll(
			   workOrderStatusChangeConsumer.ProcessMessagesAsync(),
			   stopTransactionForWorkOrderConsumer.ProcessMessagesAsync(),
			   wastageTransactionConsumer.ProcessMessagesAsync(),
			   consumableTransactionConsumer.ProcessMessagesAsync(),
			   productionTransactionConsumer.ProcessMessagesAsync(),
			   inCountingTransactionConsumer.ProcessMessagesAsync(),
			   outCountingTransactionConsumer.ProcessMessagesAsync()
		   // Add more consumer tasks as needed
		   );
		}

		await host.RunAsync();
	}
}