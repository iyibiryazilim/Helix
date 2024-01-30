namespace Helix.UI.Mobile.Modules.PurchaseModule.Dtos.BaseDto
{
    public class BasePurchaseDispatchTransactionLineDto
    {
        public short? TransactionType { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public string DocumentTrackingNumber { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public TimeSpan TransactionTime { get; set; }
        public int? ConvertedTime { get; set; }
        public short? IOType { get; set; }
        public int? ProductReferenceId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int? UnitsetReferenceId { get; set; }
        public string UnitsetCode { get; set; } = string.Empty;
        public int? SubUnitsetReferenceId { get; set; }
        public string SubUnitsetCode { get; set; } = string.Empty;
        public double? Quantity { get; set; }
        public double? UnitPrice { get; set; } = default;
        public double? VatRate { get; set; }
        public int? DivisionReferenceId { get; set; }
        public int? WarehouseReferenceId { get; set; }
        public short? WarehouseNumber { get; set; }
        public int? OrderReferenceId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? CurrentReferenceId { get; set; }
        public string CurrentCode { get; set; } = string.Empty;
        public int? DispatchReferenceId { get; set; }
        public int? SpeCodeReferenceId { get; set; }
        public string SpeCode { get; set; } = string.Empty;
        public double? ConversionFactor { get; set; }
        public double? OtherConversionFactor { get; set; }
    }
}
