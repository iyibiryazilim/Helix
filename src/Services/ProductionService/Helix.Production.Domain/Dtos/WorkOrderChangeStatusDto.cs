namespace Helix.ProductionService.Domain.Dtos;

public record WorkOrderChangeStatusDto(
	string ficheNo,
	int status,
	short deleteFiche)
{
}
