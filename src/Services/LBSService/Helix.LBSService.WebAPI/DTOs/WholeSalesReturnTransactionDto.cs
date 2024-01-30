namespace Helix.LBSService.WebAPI.DTOs
{
	public class WholeSalesReturnTransactionDto : ProductTransactionDto
	{
		public IList<WholeSalesReturnTransactionLineDto> Lines { get; set; }

		public WholeSalesReturnTransactionDto()
		{
			TransactionType = 3;
			Lines = new List<WholeSalesReturnTransactionLineDto>();
		}
	}
	public class WholeSalesReturnTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public WholeSalesReturnTransactionLineDto()
		{
			TransactionType = 3;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
