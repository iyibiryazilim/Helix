using Helix.LBSService.EventConsumer.Dtos;
using Helix.LBSService.EventConsumer.Helper;

namespace Helix.LBSService.EventConsumer.Consumers
{
	public class TransferTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<TransferTransactionDto> _messageConsumer;

        public TransferTransactionConsumer(IService<TransferTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<TransferTransactionDto>(
                service: service,
                queueName: "ProductService.TransferTransactionIns",
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
