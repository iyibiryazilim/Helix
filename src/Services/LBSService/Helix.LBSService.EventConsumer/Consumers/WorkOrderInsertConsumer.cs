using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;
namespace Helix.LBSService.EventConsumer.Consumers
{
    public class WorkOrderInsertConsumer : IDisposable
    {
        private readonly MessageConsumer<WorkOrdersDto> _messageConsumer;

        public WorkOrderInsertConsumer(IService<WorkOrdersDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<WorkOrdersDto>(
                service,
                "",
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
