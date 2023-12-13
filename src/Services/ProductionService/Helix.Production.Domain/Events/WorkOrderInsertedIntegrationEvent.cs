using Helix.EventBus.Base.Events;

namespace Helix.ProductionService.Domain.Events;

public class WorkOrderInsertedIntegrationEvent : IntegrationEvent
{
	public int WorkOrderId { get; private set; }
	public int ProductReferenceId { get; private set; }
	public double ActualQuantity { get; private set; }
	public int SubUnitsetReferenceId { get; private set; }
	public short CalculatedMethod { get; private set; }
	public bool IsIncludeSideProduct { get; private set; }

	public WorkOrderInsertedIntegrationEvent(int workOrderId, int productReferenceId, double actualQuantity, int subUnitsetReferenceId, short calculatedMethod, bool ısIncludeSideProduct)
	{
		WorkOrderId = workOrderId;
		ProductReferenceId = productReferenceId;
		ActualQuantity = actualQuantity;
		SubUnitsetReferenceId = subUnitsetReferenceId;
		CalculatedMethod = calculatedMethod;
		IsIncludeSideProduct = ısIncludeSideProduct;
	}
}
