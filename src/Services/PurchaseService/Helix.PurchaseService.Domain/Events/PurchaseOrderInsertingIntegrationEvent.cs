﻿using Helix.EventBus.Base.Events;
using Helix.PurchaseService.Domain.Dtos;

namespace Helix.PurchaseService.Domain.Events;

public class PurchaseOrderInsertingIntegrationEvent : IntegrationEvent
{
	public PurchaseOrderInsertingIntegrationEvent(string? employeeOid, int? referenceId, string? code, string? salesmanCode, DateTime? orderDate, string? description, short? warehouseNumber, string? customerCode, string? shipmentAccountCode, string? projectCode, List<PurchaseOrderLineDto> lines)
	{
		EmployeeOid = employeeOid;
		ReferenceId = referenceId;
		Code = code;
		SalesmanCode = salesmanCode;
		OrderDate = orderDate;
		Description = description;
		WarehouseNumber = warehouseNumber;
		CustomerCode = customerCode;
		ShipmentAccountCode = shipmentAccountCode;
		ProjectCode = projectCode;
		Lines = lines;
	}
	public string? EmployeeOid { get; set; }
	public int? ReferenceId { get; set; }
	public string? Code { get; set; } = string.Empty;
	public string? SalesmanCode { get; set; } = string.Empty;
	public DateTime? OrderDate { get; set; } = DateTime.Now;
	public string? Description { get; set; } = string.Empty;
	public short? WarehouseNumber { get; set; }
	public string? CustomerCode { get; set; } = string.Empty;
	public string? ShipmentAccountCode { get; set; } = string.Empty;
	public string? ProjectCode { get; set; } = string.Empty;
	public List<PurchaseOrderLineDto> Lines { get; set; }
}
