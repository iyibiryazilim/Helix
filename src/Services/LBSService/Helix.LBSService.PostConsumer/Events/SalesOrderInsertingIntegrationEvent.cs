﻿using Helix.EventBus.Base.Events;
using Helix.LBSService.PostConsumer.Models;

namespace Helix.LBSService.PostConsumer.Events
{
	public class SalesOrderInsertingIntegrationEvent : IntegrationEvent
	{
		public SalesOrderInsertingIntegrationEvent()
		{
			Lines = new List<SalesOrderLineDto>();
		}

		public IList<SalesOrderLineDto> Lines { get; set; }

		public string? EmployeeOid { get; set; }
		public int? ReferenceId { get; set; }
		public string? Code { get; set; } = string.Empty;
		public string SalesmanCode { get; set; } = string.Empty;
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public string? Description { get; set; } = string.Empty;
		public short WarehouseNumber { get; set; }
		public string CurrentCode { get; set; } = string.Empty;
		public string ShipmentAccountCode { get; set; } = string.Empty;
		public double? Total { get; set; } = default;
		public double? TotalVat { get; set; } = default;
		public double? NetTotal { get; set; } = default;
		public double? DiscountTotal { get; set; } = default;
		public short? CurrencyType { get; set; } = default;
		public string ProjectCode { get; set; } = string.Empty;
	}

	public class SalesOrderLineDto : OrderLineDto
	{
		public SalesOrderLineDto()
		{
		}
	}
}