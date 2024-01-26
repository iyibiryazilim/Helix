namespace Helix.LBSService.Tiger.DTOs
{
	public class RetailSalesReturnDispatchTransactionDto : ProductTransactionDto
	{
		public IList<RetailSalesReturnDispatchTransactionLineDto> Lines { get; set; }

		public RetailSalesReturnDispatchTransactionDto()
		{
			base.TransactionType = 2;
 			Lines = new List<RetailSalesReturnDispatchTransactionLineDto>();
		}
	}
	public class RetailSalesReturnDispatchTransactionLineDto : ProductTransactionLineDto
	{
		public RetailSalesReturnDispatchTransactionLineDto()
		{
			TransactionType = 2;
 			SeriLotTransactions = new List<SeriLotTransactionDto>();

		}
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }
	}
}
