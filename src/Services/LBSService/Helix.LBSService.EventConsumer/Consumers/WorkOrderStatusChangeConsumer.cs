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
    public class WorkOrderStatusChangeConsumer : IDisposable
    {
        private readonly MessageConsumer<WorkOrderChangeStatusDto> _messageConsumer;

        public WorkOrderStatusChangeConsumer(IService<WorkOrderChangeStatusDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<WorkOrderChangeStatusDto>(
                service,
                "ProductionService.WorkOrderChangeStatusInserted",
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
