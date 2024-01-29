using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Models;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;

namespace Helix.LBSService.EventConsumer.WorkOrder
{
	public class WorkOrderStatusChangeConsumer : IDisposable
	{
		private readonly MessageConsumer<WorkOrderChangeStatusDto> _messageConsumer;

		public WorkOrderStatusChangeConsumer(IService<WorkOrderChangeStatusDto> wholeSalesReturnTransactionService, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<WorkOrderChangeStatusDto>(
				wholeSalesReturnTransactionService,
				"ProductionService.WorkOrderChangeStatusInserted",
				"HelixTopicName",
				httpClient
			);
		}

		public async Task ProcessMessagesAsync()
		{
			await _messageConsumer.ProcessMessagesAsync();
		}

		public void Dispose()
		{
			_messageConsumer.Dispose();
		}
	}
}
 