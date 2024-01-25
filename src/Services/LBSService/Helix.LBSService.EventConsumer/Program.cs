using Helix.LBSService.EventConsumer.WorkOrder;
using Helix.LBSService.Tiger.DataStores;
using Helix.LBSService.Tiger.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
	static async Task Main(string[] args)
	{
		var builder = Host.CreateDefaultBuilder(args);

		builder.ConfigureServices((hostContext, services) =>
		{
			services.AddSingleton<ILG_WorkOrderService, LG_WorkOrderDataStore>();
			services.AddSingleton<IUnityApplicationService, UnityApplicationDataStore>();

			// Register multiple consumers
			services.AddSingleton<WorkOrderStatusChangeConsumer>();
			services.AddSingleton<StopTransactionForWorkOrderConsumer>(); // Assuming you have a consumer for this

			// Add more consumers as needed
		});

		var host = builder.Build();

		using (var scope = host.Services.CreateScope())
		{
			var serviceProvider = scope.ServiceProvider;
			var workOrderService = serviceProvider.GetRequiredService<ILG_WorkOrderService>();

			// Get and start each consumer
			var workOrderStatusChangeConsumer = serviceProvider.GetRequiredService<WorkOrderStatusChangeConsumer>();
			var stopTransactionForWorkOrderConsumer = serviceProvider.GetRequiredService<StopTransactionForWorkOrderConsumer>();

			// Use workOrderService and consumers as needed
			await Task.WhenAll(
				workOrderStatusChangeConsumer.ProcessMessagesAsync(),
				stopTransactionForWorkOrderConsumer.ProcessMessagesAsync()
			// Add more consumer tasks as needed
			);
		}

		await host.RunAsync();
	}
}