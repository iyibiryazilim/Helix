using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.Consumers
{
    public class PurchaseDispatchTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<PurchaseDispatchTransactionDto> _messageConsumer;

        public PurchaseDispatchTransactionConsumer(IService<PurchaseDispatchTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<PurchaseDispatchTransactionDto>(
                service: service,
                queueName: "PurchaseService.PurchaseDispatchTransactionInserted",
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
