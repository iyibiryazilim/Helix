namespace Helix.LBSService.Tiger.DTOs
{
	public class PurchaseReturnDispatchTransactionDto : ProductTransactionDto
	{
		public IList<PurchaseReturnDispatchTransactionLineDto> Lines { get; set; }

		public PurchaseReturnDispatchTransactionDto()
		{
			base.TransactionType = 6;
 			Lines = new List<PurchaseReturnDispatchTransactionLineDto>();
		}
	}
	public class PurchaseReturnDispatchTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public PurchaseReturnDispatchTransactionLineDto()
		{
			base.TransactionType = (short)6;
 			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
