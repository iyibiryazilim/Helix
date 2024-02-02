namespace Helix.LBSService.WebAPI.DTOs
{
	public class PurchaseReturnDispatchTransactionDto : DispatchTransactionDto
	{
		public IList<PurchaseReturnDispatchTransactionLineDto> Lines { get; set; }

		public PurchaseReturnDispatchTransactionDto()
		{
			TransactionType = 6;
			Lines = new List<PurchaseReturnDispatchTransactionLineDto>();
		}
	}
	public class PurchaseReturnDispatchTransactionLineDto : DispatchTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public PurchaseReturnDispatchTransactionLineDto()
		{
			TransactionType = 6;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
