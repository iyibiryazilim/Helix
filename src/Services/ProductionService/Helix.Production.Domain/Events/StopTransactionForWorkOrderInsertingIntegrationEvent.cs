using Helix.EventBus.Base.Events;

namespace Helix.ProductionService.Domain.Events;

public class StopTransactionForWorkOrderInsertingIntegrationEvent : IntegrationEvent
{
	public int WorkOrderReferenceId { get; private set; }
	public int StopCauseReferenceId { get; private set; }
	public DateTime StopDate { get; private set; }
	public TimeSpan StopTime { get; private set; }

	public StopTransactionForWorkOrderInsertingIntegrationEvent(int workOrderReferenceId, int stopCauseReferenceId, DateTime stopDate, TimeSpan stopTime)
	{
		WorkOrderReferenceId = workOrderReferenceId;
		StopCauseReferenceId = stopCauseReferenceId;
		StopDate = stopDate;
		StopTime = stopTime;
	}

}
