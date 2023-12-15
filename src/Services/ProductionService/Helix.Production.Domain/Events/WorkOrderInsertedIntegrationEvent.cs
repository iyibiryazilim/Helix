using Helix.EventBus.Base.Events;

namespace Helix.ProductionService.Domain.Events;

public class WorkOrderInsertedIntegrationEvent : IntegrationEvent
{
	public int WorkOrderReferenceId { get; private set; }
	public int ProductReferenceId { get; private set; }
	public double ActualQuantity { get; private set; }
	public int SubUnitsetReferenceId { get; private set; }
	public short CalculatedMethod { get; private set; }
	public bool IsIncludeSideProduct { get; private set; }

	public WorkOrderInsertedIntegrationEvent(int workOrderReferenceId, int productReferenceId, double actualQuantity, int subUnitsetReferenceId, short calculatedMethod, bool ısIncludeSideProduct)
	{
		WorkOrderReferenceId = workOrderReferenceId;
		ProductReferenceId = productReferenceId;
		ActualQuantity = actualQuantity;
		SubUnitsetReferenceId = subUnitsetReferenceId;
		CalculatedMethod = calculatedMethod;
		IsIncludeSideProduct = ısIncludeSideProduct;
	}
}
