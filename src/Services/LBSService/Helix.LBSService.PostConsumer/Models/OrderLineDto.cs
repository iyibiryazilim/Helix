namespace Helix.LBSService.PostConsumer.Models
{
	public class OrderLineDto
	{
		public string ProductCode { get; set; } = string.Empty;
		public double Quantity { get; set; }
		public double VatRate { get; set; }
		public string VariantCode { get; set; } = string.Empty;
		public double Price { get; set; }
		public double EdtCurr { get; set; }
		public double EdtPrice { get; set; }
		public string? Description { get; set; } = string.Empty;
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public string UnitsetCode { get; set; } = string.Empty;
		public short WarehouseNumber { get; set; } = default;
	}
}
