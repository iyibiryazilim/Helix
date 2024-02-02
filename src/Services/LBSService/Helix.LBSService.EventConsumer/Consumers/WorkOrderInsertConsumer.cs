using Helix.LBSService.EventConsumer.Dtos;
using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;
namespace Helix.LBSService.EventConsumer.Consumers
{
	public class WorkOrderInsertConsumer : IDisposable
    {
        private readonly MessageConsumer<WorkOrdersDto> _messageConsumer;

        public WorkOrderInsertConsumer(IService<WorkOrdersDto> service, HttpClient httpClient)
        {
            _messageConsumer = new MessageConsumer<WorkOrdersDto>(
                service,
				"ProductionService.WorkOrderInserted",
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
