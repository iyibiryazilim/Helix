using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.Consumers
{
    public class OutCountingTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<OutCountingTransactionDto> _messageConsumer;

        public OutCountingTransactionConsumer(IService<OutCountingTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<OutCountingTransactionDto>(
                service: service,
                queueName: "ProductService.OutCountingTransactionIns",
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
