using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Models;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;

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
