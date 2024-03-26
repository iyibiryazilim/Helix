namespace Helix.ProductionService.Domain.Dtos;

public record WorkOrderChangeStatusDto(
	Guid eventId,
	string ficheNo,
	int status,
	short deleteFiche)
{
}