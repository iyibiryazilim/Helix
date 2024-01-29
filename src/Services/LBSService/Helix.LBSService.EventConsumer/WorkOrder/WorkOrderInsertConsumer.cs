using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;
namespace Helix.LBSService.EventConsumer.WorkOrder
{
	public class WorkOrderInsertConsumer : IDisposable
	{
		private readonly MessageConsumer<WorkOrdersDto> _messageConsumer;

		public WorkOrderInsertConsumer(IService<WorkOrdersDto> wholeSalesReturnTransactionService, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<WorkOrdersDto>(
				wholeSalesReturnTransactionService,
				"",
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
