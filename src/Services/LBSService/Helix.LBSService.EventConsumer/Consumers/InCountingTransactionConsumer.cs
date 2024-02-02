using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;


namespace Helix.LBSService.EventConsumer.Consumers
{
	public class InCountingTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<InCountingTransactionDto> _messageConsumer;

        public InCountingTransactionConsumer(IService<InCountingTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<InCountingTransactionDto>(
                service: service,
                queueName: "ProductService.InCountingTransactionIns",
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
