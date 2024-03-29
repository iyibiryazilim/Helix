﻿using Helix.EventBus.Base.Events;

namespace Helix.ProductionService.Domain.Events;

public class WorkOrderStopTransactionInsertingIntegrationEvent : IntegrationEvent
{
	public int WorkOrderReferenceId { get; private set; }
	public int StopCauseReferenceId { get; private set; }
	public DateTime StopDate { get; private set; }
	public TimeSpan StopTime { get; private set; }

	public WorkOrderStopTransactionInsertingIntegrationEvent(Guid eventId, int workOrderReferenceId, int stopCauseReferenceId, DateTime stopDate, TimeSpan stopTime)
	{
		Owner = eventId;
		WorkOrderReferenceId = workOrderReferenceId;
		StopCauseReferenceId = stopCauseReferenceId;
		StopDate = stopDate;
		StopTime = stopTime;
	}
}