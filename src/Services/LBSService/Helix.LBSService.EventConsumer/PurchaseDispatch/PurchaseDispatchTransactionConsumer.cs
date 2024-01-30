using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.PurchaseDispatch
{
	public class PurchaseDispatchTransactionConsumer :IDisposable
	{
		private readonly MessageConsumer<PurchaseDispatchTransactionDto> _messageConsumer;

		public PurchaseDispatchTransactionConsumer(IService<PurchaseDispatchTransactionDto> service, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<PurchaseDispatchTransactionDto>(
				service: service,
				queueName: "SalesService.RetailSalesDispatchTransactionIns",
				exchange: "HelixTopicName",
				httpClient: httpClient
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
