using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.RetailSalesDispatch
{
	public class RetailSalesDispatchTransactionConsumer : IDisposable
	{
		private readonly MessageConsumer<RetailSalesDispatchTransactionDto> _messageConsumer;

		public RetailSalesDispatchTransactionConsumer(IService<RetailSalesDispatchTransactionDto> wholeSalesReturnTransactionService, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<RetailSalesDispatchTransactionDto>(
				wholeSalesReturnTransactionService,
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
