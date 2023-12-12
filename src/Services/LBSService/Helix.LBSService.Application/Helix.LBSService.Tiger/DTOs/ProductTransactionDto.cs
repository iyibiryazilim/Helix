namespace Helix.LBSService.Tiger.DTOs
{
	public class ProductTransactionDto
	{
		public int ReferenceId { get; set; }
		public DateTime TransactionDate { get; set; } = DateTime.Now;
		public string TransactionTime { get; set; } = string.Empty;
		public int ConvertedTime { get; set; }
		public int OrderReference { get; set; } = 0;
		public string Code { get; set; } = string.Empty;
		public short GroupType { get; set; } = 0;
		public short IOType { get; set; } = 0;
		public short TransactionType { get; set; } = 0;
		public string TransactionTypeName { get; set; } = string.Empty;
		public int? WarehouseNumber { get; set; }
		public int? CurrentReferenceId { get; set; }
		public string? CurrentCode { get; set; }
		public double Total { get; set; } = 0.0;
		public double TotalVat { get; set; } = 0.0;
		public double NetTotal { get; set; } = 0.0;
		public string Description { get; set; } = string.Empty;
		public short DispatchType { get; set; } = 0;
		public int CarrierReferenceId { get; set; } = 0;
		public string CarrierCode { get; set; } = string.Empty;
		public int DriverReferenceId { get; set; } = 0;
		public string DriverFirstName { get; set; } = string.Empty;
		public string DriverLastName { get; set; } = string.Empty;
		public string IdentityNumber { get; set; } = string.Empty;
		public string Plaque { get; set; } = string.Empty;
		public int ShipInfoReferenceId { get; set; } = 0;
		public string ShipInfoCode { get; set; } = string.Empty;
		public string ShipInfoName { get; set; } = string.Empty;
		public string SpeCode { get; set; } = string.Empty;
		public short DispatchStatus { get; set; } = 0;
		public short IsEDispatch { get; set; } = 0;
		public string DoCode { get; set; } = string.Empty;
		public string DocTrackingNumber { get; set; } = string.Empty;
		public short IsEInvoice { get; set; } = 0;
		public short EDispatchProfileId { get; set; } = 0;
		public short EInvoiceProfileId { get; set; } = 0;
	}
}
