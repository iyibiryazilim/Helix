namespace Helix.SharedEntity.DTOs.Base
{
	public class ProductTransactionDto : BaseDto
	{
		public int ReferenceId { get; set; }
		public DateTime TransactionDate { get; set; } = DateTime.Now;
		public string TransactionTime { get; set; } = string.Empty;
		public int ConvertedTime { get; set; }
		public int OrderReference { get; set; } = default;
		public string Code { get; set; } = string.Empty;
		public short GroupType { get; set; } = default;
		public short IOType { get; set; } = default;
		public short TransactionType { get; set; } = default;
		public string TransactionTypeName { get; set; } = string.Empty;
		public int? WarehouseNumber { get; set; }
		public int? CurrentReferenceId { get; set; }
		public string? CurrentCode { get; set; }
		public double Total { get; set; } = default;
		public double TotalVat { get; set; } = default;
		public double NetTotal { get; set; } = default;
		public string Description { get; set; } = string.Empty;
		public short DispatchType { get; set; } = default;
		public int CarrierReferenceId { get; set; } = default;
		public string CarrierCode { get; set; } = string.Empty;
		public int DriverReferenceId { get; set; } = default;
		public string DriverFirstName { get; set; } = string.Empty;
		public string DriverLastName { get; set; } = string.Empty;
		public string IdentityNumber { get; set; } = string.Empty;
		public string Plaque { get; set; } = string.Empty;
		public int ShipInfoReferenceId { get; set; } = default;
		public string ShipInfoCode { get; set; } = string.Empty;
		public string ShipInfoName { get; set; } = string.Empty;
		public string SpeCode { get; set; } = string.Empty;
		public short DispatchStatus { get; set; } = default;
		public short IsEDispatch { get; set; } = default;
		public string DoCode { get; set; } = string.Empty;
		public string DocTrackingNumber { get; set; } = string.Empty;
		public short IsEInvoice { get; set; } = default;
		public short EDispatchProfileId { get; set; } = default;
		public short EInvoiceProfileId { get; set; } = default;
	}
}
