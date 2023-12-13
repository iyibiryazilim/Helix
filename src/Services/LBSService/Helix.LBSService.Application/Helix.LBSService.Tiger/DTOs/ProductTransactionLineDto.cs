namespace Helix.LBSService.Tiger.DTOs
{
	public class ProductTransactionLineDto
	{
		public int? ProductReferenceId { get; set; }

		public string? ProductCode { get; set; } = string.Empty;


		public double? Quantity { get; set; }

		public int? SubUnitsetReferenceId { get; set; }

		public string? SubUnitsetCode { get; set; } = string.Empty;


		public DateTime TransactionDate { get; set; } = DateTime.Now;


		public short? TransactionType { get; set; }

		public string? TransactionTypeName { get; set; } = string.Empty;


		public int? ReferenceId { get; set; }

		public string TransactionTime { get; set; } = string.Empty;


		public int? ConvertedTime { get; set; }

		public int? IOType { get; set; }

		public int? WarehouseNumber { get; set; }

		public double? UnitPrice { get; set; }

		public double? VatRate { get; set; }

		public int? OrderReferenceId { get; set; }

		public string? Description { get; set; } = string.Empty;


		public int? DispatchReferenceId { get; set; }

		public string? SpeCode { get; set; } = string.Empty;


		public double? ConversionFactor { get; set; }

		public double? OtherConversionFactor { get; set; }
	}
}
