namespace Helix.ProductionService.Domain.Dtos;

public record StopTransactionForWorkOrderDto(
	int workOrderReferenceId,
	int stopCauseReferenceId,
	DateTime stopDate,
	TimeSpan stopTime)
{
}
