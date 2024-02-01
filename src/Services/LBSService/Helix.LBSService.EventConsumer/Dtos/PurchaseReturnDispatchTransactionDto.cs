namespace Helix.LBSService.EventConsumer.Dtos
{
	public class PurchaseReturnDispatchTransactionDto : ProductTransactionDto
	{
		public IList<PurchaseReturnDispatchTransactionLineDto> Lines { get; set; }

		public PurchaseReturnDispatchTransactionDto()
		{
			TransactionType = 6;
			Lines = new List<PurchaseReturnDispatchTransactionLineDto>();
		}
	}
	public class PurchaseReturnDispatchTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public PurchaseReturnDispatchTransactionLineDto()
		{
			TransactionType = 6;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
