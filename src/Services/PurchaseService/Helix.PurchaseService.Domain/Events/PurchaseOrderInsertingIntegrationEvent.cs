using Helix.EventBus.Base.Events;
using Helix.PurchaseService.Domain.Dtos;

namespace Helix.PurchaseService.Domain.Events;

public class PurchaseOrderInsertingIntegrationEvent : IntegrationEvent
{
	public PurchaseOrderInsertingIntegrationEvent(string? employeeOid, int? referenceId, string? code, string? salesmanCode, DateTime? orderDate, string? description, short? warehouseNumber, string? customerCode, string? shipmentAccountCode, string? projectCode, List<PurchaseOrderLineDto> lines, double? total, double? totalVat, double? netTotal, double? discountTotal)
	{
		EmployeeOid = employeeOid;
		ReferenceId = referenceId;
		Code = code;
		SalesmanCode = salesmanCode;
		OrderDate = orderDate;
		Description = description;
		WarehouseNumber = warehouseNumber;
		CurrentCode = customerCode;
		ShipmentAccountCode = shipmentAccountCode;
		ProjectCode = projectCode;
		Lines = lines;
		Total = total;
		TotalVat = totalVat;
		NetTotal = netTotal;
		DiscountTotal = discountTotal;
	}

	public string? EmployeeOid { get; set; }
	public int? ReferenceId { get; set; }
	public string? Code { get; set; } = string.Empty;
	public string? SalesmanCode { get; set; } = string.Empty;
	public DateTime? OrderDate { get; set; } = DateTime.Now;
	public string? Description { get; set; } = string.Empty;
	public short? WarehouseNumber { get; set; }
	public string? CurrentCode { get; set; } = string.Empty;
	public string? ShipmentAccountCode { get; set; } = string.Empty;
	public string? ProjectCode { get; set; } = string.Empty;
	public double? Total { get; set; } = default;
	public double? TotalVat { get; set; } = default;
	public double? NetTotal { get; set; } = default;
	public double? DiscountTotal { get; set; } = default;
	public List<PurchaseOrderLineDto> Lines { get; set; }
}