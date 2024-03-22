namespace Helix.LBSService.WebAPI.DTOs
{
	public class OrderLineDto
	{
		public string ProductCode { get; set; } = string.Empty;
		public double Quantity { get; set; }
		public double VatRate { get; set; }
		public string VariantCode { get; set; } = string.Empty;
		public double UnitPrice { get; set; }
		public double EdtCurr { get; set; }
		public double EdtPrice { get; set; }
		public string? Description { get; set; } = string.Empty;
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public string UnitsetCode { get; set; } = string.Empty;
		public short WarehouseNumber { get; set; } = default;
		public double? Total { get; set; } = default;
		public double? TotalVat { get; set; } = default;
		public double? NetTotal { get; set; } = default;
		public double? TotalDiscount { get; set; } = default;
		public double? DiscountRate { get; set; } = default;
		public short? CurrencyType { get; set; } = default;
	}
}