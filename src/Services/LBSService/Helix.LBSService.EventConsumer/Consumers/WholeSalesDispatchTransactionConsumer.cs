using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Consumers
{
    public class WholeSalesDispatchTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<WholeSalesDispatchTransactionDto> _messageConsumer;

        public WholeSalesDispatchTransactionConsumer(IService<WholeSalesDispatchTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<WholeSalesDispatchTransactionDto>(
                service,
				"SalesService.WholeSalesDispatchTransactionIns",
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
