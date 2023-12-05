﻿namespace Helix.SharedEntity.Models
{
	public class SeriLotTransaction
	{
		public int ReferenceId { get; set; }
		public DateTime Date { get; set; } = default; 
		public string StockLocationCode { get; set; } = string.Empty;
		public string DestinationStockLocationCode { get; set; } = string.Empty;
		public int? WarehouseNumber { get; set; } = default;
		public string ProductTransactionCode { get; set; } = string.Empty;
		public int InProductTransactionLineReferenceId { get; set; } = default;
		public int OutProductTransactionLineReferenceId { get; set; } = default;
		public short? SerilotType { get; set; } = default;
		public double? Quantity { get; set; } = default;
		public double? RemainingQuantity { get; set; } = default;
 		public double? InSerilotTransactionQuantity { get; set; } = default;
		public int IOCode { get; set; }
		public string SubUnitsetCode { get; set; } = string.Empty;
		public double ConversionFactor { get; set; }
		public double OtherConversionFactor { get; set; }
	}
}
