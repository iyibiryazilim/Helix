namespace Helix.LBSService.WebAPI.DTOs
{
	public class DispatchTransactionDto : ProductTransactionDto
	{
		public int? CurrentReferenceId { get; set; }
		public string? CurrentCode { get; set; } = string.Empty;
		public double Total { get; set; } = default;
		public double TotalVat { get; set; } = default;
		public double NetTotal { get; set; } = default;
		public short? DispatchType { get; set; }
        public int? CarrierReferenceId { get; set; }
		public string? CarrierCode { get; set; } = string.Empty;
        public int? DriverReferenceId { get; set; }
		public string? DriverFirstName { get; set; } = string.Empty;
		public string? DriverLastName { get; set; } = string.Empty;
		public string? IdentityNumber { get; set; } = string.Empty;
		public string? Plaque { get; set; } = string.Empty;
        public int? ShipInfoReferenceId { get; set; }
		public string? ShipInfoCode { get; set; } = string.Empty;
        public int? DispatchStatus { get; set; }
		public int? IsEDispatch { get; set; }
		public int? IsEInvoice { get; set; }
		public int? EDispatchProfileId { get; set; }
        public int? EInvoiceProfileId { get; set; }  
	}
}
