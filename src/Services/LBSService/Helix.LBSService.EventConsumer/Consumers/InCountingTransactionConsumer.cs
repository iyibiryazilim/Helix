using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;


namespace Helix.LBSService.EventConsumer.Consumers
{
	public class InCountingTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<InCountingTransactionDto> _messageConsumer;

        public InCountingTransactionConsumer(IService<InCountingTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<InCountingTransactionDto>(
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
