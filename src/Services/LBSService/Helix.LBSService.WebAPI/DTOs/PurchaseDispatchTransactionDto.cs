namespace Helix.LBSService.WebAPI.DTOs
{
	public class PurchaseDispatchTransactionDto : ProductTransactionDto
	{
		public IList<PurchaseDispatchTransactionLineDto> Lines { get; set; }

		public PurchaseDispatchTransactionDto()
		{
			TransactionType = 1;
			Lines = new List<PurchaseDispatchTransactionLineDto>();
		}
	}
	public class PurchaseDispatchTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public PurchaseDispatchTransactionLineDto()
		{
			TransactionType = 1;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
