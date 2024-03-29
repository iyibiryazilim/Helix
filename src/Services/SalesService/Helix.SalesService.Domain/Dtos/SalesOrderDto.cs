﻿namespace Helix.SalesService.Domain.Dtos;

public record SalesOrderDto(
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
	double? discountTotal,
	string? employeeOid,
	string? description,
	short? statusi,
	short? currencyType,
	List<SalesOrderLineDto> lines)
{
}