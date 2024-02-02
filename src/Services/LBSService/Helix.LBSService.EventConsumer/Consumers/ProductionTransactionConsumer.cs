using Helix.LBSService.EventConsumer.Dtos;
using Helix.LBSService.EventConsumer.Helper;


namespace Helix.LBSService.EventConsumer.Consumers
{
	public class ProductionTransactionConsumer : IDisposable
	{
		private readonly MessageConsumer<ProductionTransactionDto> _messageConsumer;

		public ProductionTransactionConsumer(IService<ProductionTransactionDto> service, HttpClient httpClient)
		{
			_messageConsumer = new MessageConsumer<ProductionTransactionDto>(
				service: service,
				queueName: "ProductService.ProductionTransactionIns",
				exchange: "HelixTopicName",
				httpClient: httpClient,
				new ManualResetEvent(false)
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
