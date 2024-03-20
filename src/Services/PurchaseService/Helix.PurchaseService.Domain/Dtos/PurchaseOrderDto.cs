namespace Helix.PurchaseService.Domain.Dtos;

public record PurchaseOrderDto(
	int? referenceId,
	DateTime orderDate,
	int? transactionType,
	string? transactionTypeName,
	short? orderType,
	string? code,
	string? salesmanCode,
	string? warehouseName,
	string? shipmentAccountCode,
	string? projectCode,
	int? warehouseNumber,
	int? currentReferenceId,
	string? currentName,
	string? currentCode,
	double? total,
	double? totalVat,
	double? netTotal,
	string? employeeOid,
	string? description,
	short? statusi,
	List<PurchaseOrderLineDto> lines)
{

}
