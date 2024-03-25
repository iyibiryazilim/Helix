namespace Helix.LBSService.WebAPI.DTOs
{
	public class RetailSalesDispatchTransactionDto : DispatchTransactionDto
	{
		public IList<RetailSalesDispatchTransactionLineDto> Lines { get; set; }

		public RetailSalesDispatchTransactionDto()
		{
			TransactionType = 7;
			Lines = new List<RetailSalesDispatchTransactionLineDto>();
		}
	}

	public class RetailSalesDispatchTransactionLineDto : DispatchTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public RetailSalesDispatchTransactionLineDto()
		{
			TransactionType = 7;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}