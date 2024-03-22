namespace Helix.LBSService.WebAPI.DTOs
{
	public class WholeSalesDispatchTransactionDto : DispatchTransactionDto
	{
		public IList<WholeSalesDispatchTransactionLineDto> Lines { get; set; }

		public WholeSalesDispatchTransactionDto()
		{
			TransactionType = 8;
			Lines = new List<WholeSalesDispatchTransactionLineDto>();
		}
	}

	public class WholeSalesDispatchTransactionLineDto : DispatchTransactionLineDto
	{
		public WholeSalesDispatchTransactionLineDto()
		{
			TransactionType = 8;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}

		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }
	}
}