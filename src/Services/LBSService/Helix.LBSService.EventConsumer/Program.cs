using Helix.EventBus.Base;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.LBSService.EventConsumer;
using Helix.LBSService.Tiger.DataStores;
using Helix.LBSService.Tiger.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ILG_WorkOrderService, LG_WorkOrderDataStore>();
builder.Services.AddSingleton<IUnityApplicationService, UnityApplicationDataStore>();

var serviceProvider = builder.Services.BuildServiceProvider();
string message = ConsumeEvent(new EventBusConfig{
	ConnectionRetryCount = 5,
	SubscriperClientAppName = "ProductionService",
	DefaultTopicName = "HelixTopicName",
	EventBusType = EventBusType.RabbitMQ,
	EventNameSuffix = nameof(IntegrationEvent),
}, serviceProvider, @event: new StopTransactionForWorkOrderInsertedIntegrationEvent());
Console.WriteLine(message);
//Run command as host
using IHost host = builder.Build();
await host.RunAsync();

string ConsumeEvent(EventBusConfig config, ServiceProvider serviceProvider, IntegrationEvent @event)
{
	var result = "";
	try
	{
		var eventBus = EventBusFactory.Create(config, serviceProvider);
		eventBus.Consume(@event);
		var consumer = eventBus.GetConsumer();

		consumer.Received += (model, ea) =>
		{
			var body = ea.Body.ToArray();
			Console.WriteLine($" [x] Received {Encoding.UTF8.GetString(body)}");
			result = Encoding.UTF8.GetString(body);
			eventBus.GetConsumerChannel().BasicAck(ea.DeliveryTag, false);
		};
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error setting up consumer: {ex.Message}");
		throw;
	}
	return result;
}