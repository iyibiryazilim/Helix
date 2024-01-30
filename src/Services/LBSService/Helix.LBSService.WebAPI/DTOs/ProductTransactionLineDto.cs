namespace Helix.LBSService.WebAPI.DTOs
{
	public class ProductTransactionLineDto
	{
		public int? ProductReferenceId { get; set; }
		public string? ProductCode { get; set; } = string.Empty;
		public int UnitsetReferenceId { get; set; }
		public string UnitsetCode { get; set; } = string.Empty;
		public double? Quantity { get; set; }
		public int? SubUnitsetReferenceId { get; set; }
		public string? SubUnitsetCode { get; set; } = string.Empty;
		public DateTime TransactionDate { get; set; } = DateTime.Now;
		public short? TransactionType { get; set; }
		public int? IOType { get; set; }
		public int? WarehouseNumber { get; set; }
		public string? Description { get; set; } = string.Empty;
		public string? SpeCode { get; set; } = string.Empty;
		public double? ConversionFactor { get; set; }
		public double? OtherConversionFactor { get; set; }
	}
}
