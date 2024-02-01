using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Consumers
{
	public class PurchaseReturnDispatchTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<PurchaseReturnDispatchTransactionDto> _messageConsumer;

        public PurchaseReturnDispatchTransactionConsumer(IService<PurchaseReturnDispatchTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<PurchaseReturnDispatchTransactionDto>(
                service,
				"PurchaseService.PurchaseReturnDispatchTransactionInserted",
                "HelixTopicName",
                httpClient
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
