using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.WorkOrder
{
	public class StopTransactionForWorkOrderConsumer : IDisposable
	{
		private readonly MessageConsumer<StopTransactionForWorkOrderDto> _messageConsumer;

		public StopTransactionForWorkOrderConsumer(IService<StopTransactionForWorkOrderDto> service, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<StopTransactionForWorkOrderDto>(
				service,
				"ProductionService.StopTransactionForWorkOrderInserted",
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
