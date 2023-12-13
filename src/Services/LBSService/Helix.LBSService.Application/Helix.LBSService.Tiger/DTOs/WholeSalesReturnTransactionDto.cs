namespace Helix.LBSService.Tiger.DTOs
{
	public class WholeSalesReturnTransactionDto : ProductTransactionDto
	{
		public IList<WholeSalesReturnTransactionLineDto> Lines { get; set; }

		public WholeSalesReturnTransactionDto()
		{
			base.TransactionType = 3;
			base.TransactionTypeName = "Toptan Satış İade İrsaliyesi";
			Lines = new List<WholeSalesReturnTransactionLineDto>();
		}
	}
	public class WholeSalesReturnTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public WholeSalesReturnTransactionLineDto()
		{
			base.TransactionType = (short)3;
			base.TransactionTypeName = "Toptan Satış İade İrsaliyesi";
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
