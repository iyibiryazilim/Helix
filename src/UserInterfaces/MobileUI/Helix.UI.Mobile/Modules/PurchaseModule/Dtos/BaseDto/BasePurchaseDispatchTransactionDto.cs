namespace Helix.UI.Mobile.Modules.PurchaseModule.Dtos.BaseDto
{
    public class BasePurchaseDispatchTransactionDto
    {
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string TransactionTime { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public short? GroupType { get; set; }
        public short? IOType { get; set; }
        public short? TransactionType { get; set; }
        public int? WarehouseNumber { get; set; }
        public int? CurrentReferenceId { get; set; }
        public string CurrentCode { get; set; } = string.Empty;
        public double Total { get; set; }
        public double TotalVat { get; set; }
        public double NetTotal { get; set; }
        public string Description { get; set; } = string.Empty;
        public short? DispatchType { get; set; }
        public string SpeCode { get; set; } = string.Empty;
        public short? DispatchStatus { get; set; }
        public short? IsEDispatch { get; set; }
        public string DoCode { get; set; } = string.Empty;
        public string DocTrackingNumber { get; set; } = string.Empty;
        public short? IsEInvoice { get; set; }
        public short? EDispatchProfileId { get; set; }
        public short? EInvoiceProfileId { get; set; }
        public string EmployeeOid { get; set; }
    }
}
