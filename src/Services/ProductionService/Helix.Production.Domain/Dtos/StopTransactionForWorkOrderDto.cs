namespace Helix.ProductionService.Domain.Dtos;

public record StopTransactionForWorkOrderDto(
	Guid eventId,
	int workOrderReferenceId,
	int stopCauseReferenceId,
	DateTime stopDate,
	TimeSpan stopTime)
{
}