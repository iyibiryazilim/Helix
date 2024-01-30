using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Models;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Diagnostics;
using System.Text;

namespace Helix.LBSService.EventConsumer.Consumers
{
    public class PurchaseReturnDispatchTransactionConsumer : IDisposable
    {
        private readonly MessageConsumer<PurchaseReturnDispatchTransactionDto> _messageConsumer;

        public PurchaseReturnDispatchTransactionConsumer(IService<PurchaseReturnDispatchTransactionDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<PurchaseReturnDispatchTransactionDto>(
                service,
                "SalesService.RetailSalesDispatchTransactionIns",
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
