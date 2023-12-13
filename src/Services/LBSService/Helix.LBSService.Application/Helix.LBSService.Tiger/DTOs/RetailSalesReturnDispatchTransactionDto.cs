namespace Helix.LBSService.Tiger.DTOs
{
	public class RetailSalesReturnDispatchTransactionDto : ProductTransactionDto
	{
		public IList<RetailSalesReturnDispatchTransactionLineDto> Lines { get; set; }

		public RetailSalesReturnDispatchTransactionDto()
		{
			base.TransactionType = 2;
			base.TransactionTypeName = "Perakende Satış İade İrsaliyesi";
			Lines = new List<RetailSalesReturnDispatchTransactionLineDto>();
		}
	}
	public class RetailSalesReturnDispatchTransactionLineDto : ProductTransactionLineDto
	{
		public RetailSalesReturnDispatchTransactionLineDto()
		{
			TransactionType = 2;
			TransactionTypeName = "Perakende Satış İade İrsaliyesi";
			SeriLotTransactions = new List<SeriLotTransactionDto>();

		}
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }
	}
}
