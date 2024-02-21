namespace Helix.UI.Mobile.Modules.ProductModule.Dtos.BaseDto
{
    public class BaseProductTransactionDto
    {
        public int ReferenceId { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string Code { get; set; } = string.Empty;
        public short GroupType { get; set; } = 3;
        public short IOType { get; set; } = 0;
        public short TransactionType { get; set; } = 0;
        public int? WarehouseNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public string SpeCode { get; set; } = string.Empty;
        public string DoCode { get; set; } = string.Empty;
        public string DocTrackingNumber { get; set; } = string.Empty;
        public string EmployeeOid { get; set; }
    }
}
