namespace Helix.LBSService.EventConsumer.Dtos
{
	public class DispatchTransactionLineDto : ProductTransactionLineDto
	{
		public string? DocumentNumber { get; set; } = string.Empty;
		public string? DocumentTrackingNumber { get; set; } = string.Empty;
		public double? UnitPrice { get; set; }
		public double? VatRate { get; set; }
		public int? OrderReferenceId { get; set; }
		public int? CurrentReferenceId { get; set; }
		public string? CurrentCode { get; set; } = string.Empty;
		public int? DispatchReferenceId { get; set; }
	}
}
