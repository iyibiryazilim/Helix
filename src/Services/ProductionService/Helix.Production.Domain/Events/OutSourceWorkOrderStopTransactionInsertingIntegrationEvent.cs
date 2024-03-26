using Helix.EventBus.Base.Events;

namespace Helix.ProductionService.Domain.Events
{
	public class OutSourceWorkOrderStopTransactionInsertingIntegrationEvent : IntegrationEvent
	{
		public int WorkOrderReferenceId { get; private set; }
		public int StopCauseReferenceId { get; private set; }
		public DateTime StopDate { get; private set; }
		public TimeSpan StopTime { get; private set; }

		public OutSourceWorkOrderStopTransactionInsertingIntegrationEvent(Guid eventId, int workOrderReferenceId, int stopCauseReferenceId, DateTime stopDate, TimeSpan stopTime)
		{
			Id = eventId;
			WorkOrderReferenceId = workOrderReferenceId;
			StopCauseReferenceId = stopCauseReferenceId;
			StopDate = stopDate;
			StopTime = stopTime;
		}
	}
}