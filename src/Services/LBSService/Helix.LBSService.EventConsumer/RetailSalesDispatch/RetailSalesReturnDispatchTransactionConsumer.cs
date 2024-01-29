using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;


namespace Helix.LBSService.EventConsumer.RetailSalesDispatch
{
	public class RetailSalesReturnDispatchTransactionConsumer : IDisposable
	{
		private readonly MessageConsumer<RetailSalesReturnDispatchTransactionDto> _messageConsumer;

		public RetailSalesReturnDispatchTransactionConsumer(IService<RetailSalesReturnDispatchTransactionDto> wholeSalesReturnTransactionService, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<RetailSalesReturnDispatchTransactionDto>(
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
