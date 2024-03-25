namespace Helix.LBSService.WebAPI.DTOs
{
	public class ConsumableTransactionDto : ProductTransactionDto
	{
		public IList<ConsumableTransactionLineDto> Lines { get; set; }

		public ConsumableTransactionDto()
		{
			TransactionType = 12;
			IOType = 4;
			Lines = new List<ConsumableTransactionLineDto>();
		}
	}

	public class ConsumableTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public ConsumableTransactionLineDto()
		{
			TransactionType = 12;
			IOType = 4;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}