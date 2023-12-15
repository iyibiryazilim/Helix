using Helix.EventBus.Base;
using Helix.EventBus.Base.Abstractions;
using Helix.EventBus.Base.Events;
using Helix.EventBus.Factory;
using Helix.LBSService.EventConsumer;
using Helix.LBSService.Tiger.DataStores;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Helix.LBSSErvice.EventConsumer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ILG_WorkOrderService,LG_WorkOrderDataStore>();
builder.Services.AddSingleton<IUnityApplicationService, UnityApplicationDataStore>();

builder.Services.AddSingleton<IEventBus>(eb =>
{
	return EventBusFactory.Create(new Helix.EventBus.Base.EventBusConfig
	{
		ConnectionRetryCount = 5,
		SubscriperClientAppName = "ProductionService",
		DefaultTopicName = "HelixTopicName",
		EventBusType = EventBusType.RabbitMQ,
		EventNameSuffix = nameof(IntegrationEvent),
	}, eb);
});

var serviceProvider = builder.Services.BuildServiceProvider();
var dto = new StopTransactionForWorkOrderDto();
try
{

	var eventBus = serviceProvider.GetRequiredService<IEventBus>();
	eventBus.Consume(new StopTransactionForWorkOrderInsertedIntegrationEvent());
	var consumer = eventBus.GetConsumer();
 	consumer.Received += async (model, ea) =>
	{
		var body = ea.Body.ToArray();
		var message = Encoding.UTF8.GetString(body);
		Console.WriteLine($" [x] Received {message}");
		var sdto = JsonConvert.DeserializeObject<StopTransactionForWorkOrderDto>(message);
		dto.WorkOrderReferenceId = sdto.WorkOrderReferenceId;
		dto.StopCauseReferenceId = sdto.StopCauseReferenceId;
		dto.StopDate = sdto.StopDate;
		dto.StopTime = sdto.StopTime;
		var _workOrderService = serviceProvider.GetRequiredService<ILG_WorkOrderService>();
		var result =await _workOrderService.InsertStopTransaction(dto);
		eventBus.GetConsumerChannel().BasicAck(ea.DeliveryTag, false);
		Console.WriteLine(result.Message);

	};
	
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
	throw;
}

//Run command as host
using IHost host = builder.Build();
await host.RunAsync();
