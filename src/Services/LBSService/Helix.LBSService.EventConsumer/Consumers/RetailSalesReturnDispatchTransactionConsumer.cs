using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;


namespace Helix.LBSService.EventConsumer.Consumers
{
    public class RetailSalesReturnDispatchTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<RetailSalesReturnDispatchTransactionDto> _messageConsumer;

        public RetailSalesReturnDispatchTransactionConsumer(IService<RetailSalesReturnDispatchTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<RetailSalesReturnDispatchTransactionDto>(
                service,
				"SalesService.RetailSalesReturnDispatchTransactionIns",
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
