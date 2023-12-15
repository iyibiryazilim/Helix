using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models.BaseModel;
using Helix.LBSService.Tiger.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkOrderController : ControllerBase
	{
		ILG_WorkOrderService _workOrderService;
        public WorkOrderController(ILG_WorkOrderService workOrderService)
        {
			_workOrderService = workOrderService;
		}
        [HttpPost("Insert")]
		public async Task<DataResult<WorkOrderDto>> Insert([FromBody] WorkOrdersDto dto)
		{

			return await _workOrderService.Insert(dto);
		}
		[HttpPost("StopTransaction")]
		public async Task<DataResult<WorkOrderDto>> InsertStopTransaction()
		{
			try
			{
				var factory = new ConnectionFactory { Uri = new Uri("amqps://oqhbtvgt:Zh4cCLQdL1U3_E5dtAA0TOh7vnYUVA7g@rattlesnake.rmq.cloudamqp.com/oqhbtvgt") };
				using var connection = factory.CreateConnection();
				using var channel = connection.CreateModel();
				channel.ExchangeDeclare(exchange: "HelixTopicName", type: "direct");

				channel.QueueBind("ProductionService.StopTransactionForWorkOrderInserted", exchange: "HelixTopicName", routingKey: "ProductionService.StopTransactionForWorkOrderInserted");

				Console.WriteLine(" [*] Waiting for messages.");

				var consumer = new EventingBasicConsumer(channel);
				StopTransactionForWorkOrderDto dto = new StopTransactionForWorkOrderDto();
				channel.BasicConsume(queue: "ProductionService.StopTransactionForWorkOrderInserted", autoAck: false, consumer: consumer);
				consumer.Received += (model, ea) =>
				{
					var body = ea.Body.ToArray();
					var message = Encoding.UTF8.GetString(body);
					Console.WriteLine($" [x] Received {message}");
					dto = JsonConvert.DeserializeObject<StopTransactionForWorkOrderDto>(message);
					channel.BasicAck(ea.DeliveryTag, false);
				};
				return await _workOrderService.InsertStopTransaction(dto);
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpPost("Status")]
		public async Task<DataResult<WorkOrderDto>> InsertChangeStatus([FromBody] WorkOrderChangeStatusDto dto)
		{

			return await _workOrderService.InsertWorkOrderStatus(dto);
		}

	}
}
