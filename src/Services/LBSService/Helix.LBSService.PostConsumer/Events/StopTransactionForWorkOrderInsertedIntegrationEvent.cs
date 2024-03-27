using Helix.EventBus.Base.Events;

namespace Helix.LBSService.PostConsumer.Events
{
	public class StopTransactionForWorkOrderInsertedIntegrationEvent : IntegrationEvent
	{
		public int WorkOrderReferenceId { get; set; }
		public int StopCauseReferenceId { get; set; } 
		public DateTime StopDate { get; set; }
		public TimeSpan StopTime { get; set; }
	}
}