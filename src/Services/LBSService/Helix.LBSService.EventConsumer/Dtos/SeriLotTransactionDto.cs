namespace Helix.LBSService.EventConsumer.Dtos
{
	public class SeriLotTransactionDto
	{
		public int ReferenceId { get; set; }

		public DateTime Date { get; set; } = default;


		public string StockLocationCode { get; set; } = string.Empty;


		public string DestinationStockLocationCode { get; set; } = string.Empty;


		public int? WarehouseNumber { get; set; } = null;


		public string ProductTransactionCode { get; set; } = string.Empty;


		public int InProductTransactionLineReferenceId { get; set; } = 0;


		public int OutProductTransactionLineReferenceId { get; set; } = 0;


		public short? SerilotType { get; set; } = null;


		public double? Quantity { get; set; } = null;


		public double? RemainingQuantity { get; set; } = null;


		public double? InSerilotTransactionQuantity { get; set; } = null;


		public int IOCode { get; set; }

		public string SubUnitsetCode { get; set; } = string.Empty;


		public double ConversionFactor { get; set; }

		public double OtherConversionFactor { get; set; }
	}
}
