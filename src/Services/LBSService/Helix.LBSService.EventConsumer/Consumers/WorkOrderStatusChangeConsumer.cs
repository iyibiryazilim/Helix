using Helix.LBSService.EventConsumer.Dtos;
using Helix.LBSService.EventConsumer.Helper;

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
                httpClient,
				new ManualResetEvent(false)
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
