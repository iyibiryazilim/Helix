namespace Helix.LBSService.WebAPI.DTOs
{
	public class RetailSalesReturnDispatchTransactionDto : DispatchTransactionDto
	{
		public IList<RetailSalesReturnDispatchTransactionLineDto> Lines { get; set; }

		public RetailSalesReturnDispatchTransactionDto()
		{
			TransactionType = 2;
			Lines = new List<RetailSalesReturnDispatchTransactionLineDto>();
		}
	}
	public class RetailSalesReturnDispatchTransactionLineDto : DispatchTransactionLineDto
	{
		public RetailSalesReturnDispatchTransactionLineDto()
		{
			TransactionType = 2;
			SeriLotTransactions = new List<SeriLotTransactionDto>();

		}
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }
	}
}
