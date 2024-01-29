using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.WholeSalesDispatch
{
	public class WholeSalesDispatchTransactionConsumer : IDisposable
	{
		private readonly MessageConsumer<WholeSalesDispatchTransactionDto> _messageConsumer;

		public WholeSalesDispatchTransactionConsumer(IService<WholeSalesDispatchTransactionDto> wholeSalesReturnTransactionService, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<WholeSalesDispatchTransactionDto>(
				wholeSalesReturnTransactionService,
				"SalesService.WholeSalesDispatchTransactionIns",
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
