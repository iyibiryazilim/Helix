using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.ProductTransaction
{
	public class WastageTransactionConsumer : IDisposable
	{
		private readonly MessageConsumer<WastageTransactionDto> _messageConsumer;

		public WastageTransactionConsumer(IService<WastageTransactionDto> service, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<WastageTransactionDto>(
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
