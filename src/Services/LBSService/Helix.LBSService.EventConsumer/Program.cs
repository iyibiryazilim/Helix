using Helix.LBSService.EventConsumer.Consumers;
using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Models;
using Helix.LBSService.EventConsumer.Services;
using Helix.LBSService.Tiger.DTOs;
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

		Log.Logger.Information("Starting RabbitMQ console app...");

		ApplicationParameterModel parameters = configuration.GetSection(nameof(ApplicationParameter)).Get<ApplicationParameterModel>();
		ApplicationParameter.ApiAdress = parameters.ApiAdress;
		ApplicationParameter.RabbitMQAdress = parameters.RabbitMQAdress;

		builder.ConfigureServices((hostContext, services) =>
		{
			services.AddHttpClient();

			RegisterServices(services);

			RegisterConsumers(services);
		});

		var host = builder.Build();

		await ProcessConsumersAsync(host);

		await host.RunAsync();
	}

	private static void RegisterServices(IServiceCollection services)
	{

		//IServices
		services.AddTransient<IService<WorkOrderChangeStatusDto>, WorkOrderStatusChangeService>();
		services.AddTransient<IService<WorkOrdersDto>, WorkOrderInsertService>();
		services.AddTransient<IService<StopTransactionForWorkOrderDto>, StopTransactionForWorkOrderService>();

		services.AddTransient<IService<WholeSalesReturnTransactionDto>, WholeSalesReturnDispatchTransactionService>();
		services.AddTransient<IService<WholeSalesDispatchTransactionDto>, WholeSalesDispatchTransactionService>();
		services.AddTransient<IService<RetailSalesReturnDispatchTransactionDto>, RetailSalesReturnDispatchTransactionService>();
		services.AddTransient<IService<RetailSalesDispatchTransactionDto>, RetailSalesDispatchTransactionService>();
		services.AddTransient<IService<PurchaseReturnDispatchTransactionDto>, PurchaseReturnDispatchTransactionService>();
		services.AddTransient<IService<PurchaseDispatchTransactionDto>, PurchaseDispatchTransactionService>();

		services.AddTransient<IService<ConsumableTransactionDto>, ConsumableTransactionService>();
		services.AddTransient<IService<InCountingTransactionDto>, InCountingTransactionService>();
		services.AddTransient<IService<OutCountingTransactionDto>, OutCountingTransactionService>();
		services.AddTransient<IService<ProductionTransactionDto>, ProductionTransactionService>();
		services.AddTransient<IService<TransferTransactionDto>, TransferTransactionService>();
		services.AddTransient<IService<WastageTransactionDto>, WastageTransactionService>();

		// Add more services as needed
	}

	private static void RegisterConsumers(IServiceCollection services)
	{
		// Register consumers
		services.AddSingleton<WorkOrderStatusChangeConsumer>();
		services.AddSingleton<StopTransactionForWorkOrderConsumer>();
		services.AddSingleton<WastageTransactionConsumer>();
		services.AddSingleton<InCountingTransactionConsumer>();
		services.AddSingleton<OutCountingTransactionConsumer>();
		services.AddSingleton<ProductionTransactionConsumer>();
		services.AddSingleton<ConsumableTransactionConsumer>();
		services.AddSingleton<RetailSalesDispatchTransactionConsumer>();
		services.AddSingleton<RetailSalesReturnDispatchTransactionConsumer>();
		services.AddSingleton<PurchaseReturnDispatchTransactionConsumer>();
		services.AddSingleton<PurchaseDispatchTransactionConsumer>();
		services.AddSingleton<WastageTransactionConsumer>();
		services.AddSingleton<TransferTransactionConsumer>();
		services.AddSingleton<ProductionTransactionConsumer>();
		services.AddSingleton<OutCountingTransactionConsumer>();
		services.AddSingleton<InCountingTransactionConsumer>();
		services.AddSingleton<ConsumableTransactionConsumer>();
		services.AddSingleton<WorkOrderInsertConsumer>();

		// Add more consumers as needed
	}

	private static async Task ProcessConsumersAsync(IHost host)
	{
		using (var scope = host.Services.CreateScope())
		{
			var serviceProvider = scope.ServiceProvider;


			var workOrderStatusChangeConsumer = serviceProvider.GetRequiredService<WorkOrderStatusChangeConsumer>();
			var workOrderInsertConsumer = serviceProvider.GetRequiredService<WorkOrderInsertConsumer>();
			var stopTransactionForWorkOrderConsumer = serviceProvider.GetRequiredService<StopTransactionForWorkOrderConsumer>();

			var wastageTransactionConsumer = serviceProvider.GetRequiredService<WastageTransactionConsumer>();
			var consumableTransactionConsumer = serviceProvider.GetRequiredService<ConsumableTransactionConsumer>();
			var productionTransactionConsumer = serviceProvider.GetRequiredService<ProductionTransactionConsumer>();
			var inCountingTransactionConsumer = serviceProvider.GetRequiredService<InCountingTransactionConsumer>();
			var outCountingTransactionConsumer = serviceProvider.GetRequiredService<OutCountingTransactionConsumer>();
			var transferTransactionConsumer = serviceProvider.GetRequiredService<TransferTransactionConsumer>();

			var retailSalesDispatchTransactionConsumer = serviceProvider.GetRequiredService<RetailSalesDispatchTransactionConsumer>();
			var retailSalesReturnDispatchTransactionConsumer = serviceProvider.GetRequiredService<RetailSalesReturnDispatchTransactionConsumer>();
			var purchaseDispatchTransactionConsumer = serviceProvider.GetRequiredService<PurchaseDispatchTransactionConsumer>();
			var purchaseReturnDispatchTransactionConsumer = serviceProvider.GetRequiredService<PurchaseReturnDispatchTransactionConsumer>();
			var wholeSalesDispatchTransactionConsumer = serviceProvider.GetRequiredService<WholeSalesDispatchTransactionConsumer>();
			var wholeSalesReturnDispatchTransactionConsumer = serviceProvider.GetRequiredService<WholeSalesReturnDispatchTransactionConsumer>();

			await Task.WhenAll(
				workOrderStatusChangeConsumer.ProcessMessagesAsync(),
				wastageTransactionConsumer.ProcessMessagesAsync(),
				consumableTransactionConsumer.ProcessMessagesAsync(),
				productionTransactionConsumer.ProcessMessagesAsync(),
				inCountingTransactionConsumer.ProcessMessagesAsync(),
				outCountingTransactionConsumer.ProcessMessagesAsync(),
				retailSalesDispatchTransactionConsumer.ProcessMessagesAsync()
			// Add more consumer tasks as needed
			);
		}
	}
}