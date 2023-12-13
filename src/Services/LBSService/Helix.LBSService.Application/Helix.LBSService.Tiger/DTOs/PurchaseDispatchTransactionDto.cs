namespace Helix.LBSService.Tiger.DTOs
{
	public class PurchaseDispatchTransactionDto : ProductTransactionDto
	{
		public IList<PurchaseDispatchTransactionLineDto> Lines { get; set; }

		public PurchaseDispatchTransactionDto()
		{
			base.TransactionType = 1;
			base.TransactionTypeName = "Satınalma İrsaliyesi";
			Lines = new List<PurchaseDispatchTransactionLineDto>();
		}
	}
	public class PurchaseDispatchTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public PurchaseDispatchTransactionLineDto()
		{
			base.TransactionType = (short)1;
			base.TransactionTypeName = "Satınalma İrsaliyesi";
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
