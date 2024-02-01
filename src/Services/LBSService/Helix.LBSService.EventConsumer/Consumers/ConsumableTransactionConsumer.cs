using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Consumers
{
	public class ConsumableTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<ConsumableTransactionDto> _messageConsumer;

        public ConsumableTransactionConsumer(IService<ConsumableTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<ConsumableTransactionDto>(
                service: service,
                queueName: "ProductService.ConsumableTransactionIns",
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
