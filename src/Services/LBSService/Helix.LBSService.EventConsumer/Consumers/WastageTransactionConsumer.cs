using Helix.LBSService.EventConsumer.Dtos;
using Helix.LBSService.EventConsumer.Helper;

namespace Helix.LBSService.EventConsumer.Consumers
{
	public class WastageTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<WastageTransactionDto> _messageConsumer;

        public WastageTransactionConsumer(IService<WastageTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<WastageTransactionDto>(
                service: service,
                queueName: "ProductService.WastageTransactionIns",
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
