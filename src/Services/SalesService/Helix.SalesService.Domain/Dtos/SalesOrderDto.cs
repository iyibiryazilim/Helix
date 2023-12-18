namespace Helix.SalesService.Domain.Dtos;

public record SalesOrderDto(int referenceId,
 DateTime orderDate,
 int transactionType,
 string transactionTypeName,
 short orderType,
 string code,
string warehouseName,
int warehouseNumber,
int currentReferenceId,
 string currentName,
string currentCode,
 double total,
 double totalVat,
 double netTotal,
 string description,
 short status
	)
{

}
