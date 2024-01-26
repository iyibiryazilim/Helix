namespace Helix.LBSService.Tiger.DTOs
{
	public class WholeSalesDispatchTransactionDto : ProductTransactionDto
	{
		public IList<WholeSalesDispatchTransactionLineDto> Lines { get; set; }

		public WholeSalesDispatchTransactionDto()
		{
			base.TransactionType = 8;
 			Lines = new List<WholeSalesDispatchTransactionLineDto>();
		}
	}
	public class WholeSalesDispatchTransactionLineDto : ProductTransactionLineDto
	{
		public WholeSalesDispatchTransactionLineDto()
		{
			TransactionType = 8;
 			SeriLotTransactions = new List<SeriLotTransactionDto>();

		}
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }
	}
}
