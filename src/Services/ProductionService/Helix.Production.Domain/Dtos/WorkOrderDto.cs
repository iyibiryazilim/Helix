namespace Helix.ProductionService.Domain.Dtos;

public record WorkOrderDto(
		int workOrderReferenceId,
		int productReferenceId,
		double actualQuantity,
		int subUnitsetReferenceId,
		short calculatedMethod,
		bool isIncludeSideProduct
	)
{
}
