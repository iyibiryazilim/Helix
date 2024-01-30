using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.ProductTransaction
{
	public class ConsumableTransactionConsumer : IDisposable
	{
		private readonly MessageConsumer<ConsumableTransactionDto> _messageConsumer;

		public ConsumableTransactionConsumer(IService<ConsumableTransactionDto> service, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<ConsumableTransactionDto>(
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
