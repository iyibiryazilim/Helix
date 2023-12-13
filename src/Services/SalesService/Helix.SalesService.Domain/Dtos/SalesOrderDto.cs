namespace Helix.SalesService.Domain.Dtos;

public record SalesOrderDto(int referenceId,
	string code,
	DateTime orderDate
	)
{

}
