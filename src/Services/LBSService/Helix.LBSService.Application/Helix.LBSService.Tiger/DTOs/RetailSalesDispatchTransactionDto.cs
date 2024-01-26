namespace Helix.LBSService.Tiger.DTOs
{
	public class RetailSalesDispatchTransactionDto : ProductTransactionDto
	{
		public IList<RetailSalesDispatchTransactionLineDto> Lines { get; set; }

		public RetailSalesDispatchTransactionDto()
		{
			base.TransactionType = 7;
 			Lines = new List<RetailSalesDispatchTransactionLineDto>();
		}
	}
	public class RetailSalesDispatchTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public RetailSalesDispatchTransactionLineDto()
		{
			base.TransactionType = (short)7;
 			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
