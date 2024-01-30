using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.WholeSalesDispatch
{
	public class WholeSalesReturnDispatchTransactionConsumer : IDisposable
	{
		private readonly MessageConsumer<WholeSalesReturnTransactionDto> _messageConsumer;

		public WholeSalesReturnDispatchTransactionConsumer(IService<WholeSalesReturnTransactionDto> service, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<WholeSalesReturnTransactionDto>(
				service,
				"SalesService.RetailSalesDispatchTransactionIns",
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
