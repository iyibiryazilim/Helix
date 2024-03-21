using Helix.EventBus.Base.Events;

namespace Helix.LBSService.PostConsumer.Events
{
	public class OutSourceWorkOrderStopTransactionInsertingIntegrationEvent : IntegrationEvent
	{
		public int WorkOrderReferenceId { get; private set; }
		public int StopCauseReferenceId { get; private set; }
		public DateTime StopDate { get; private set; }
		public TimeSpan StopTime { get; private set; }
	}
}