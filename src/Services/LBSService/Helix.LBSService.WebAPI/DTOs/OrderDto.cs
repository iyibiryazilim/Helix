﻿namespace Helix.LBSService.WebAPI.DTOs
{
	public class OrderDto
	{
		public string? EmployeeOid { get; set; }
		public int? ReferenceId { get; set; }
		public string? Code { get; set; } = string.Empty;
        public string SalesmanCode { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
		public string? Description { get; set; } = string.Empty;
		public short WarehouseNumber { get; set; }
		public string CustomerCode { get; set; } = string.Empty;
		public string ShipmentAccountCode { get; set; } = string.Empty;
    }
}