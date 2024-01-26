namespace Helix.LBSService.Tiger.DTOs
{
	public class ConsumableTransactionDto : ProductTransactionDto
	{
		public IList<ConsumableTransactionLineDto> Lines { get; set; }

		public ConsumableTransactionDto()
		{
			base.TransactionType = 12;
			base.IOType = 4;
 			Lines = new List<ConsumableTransactionLineDto>();
		}
	}
	public class ConsumableTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public ConsumableTransactionLineDto()
		{
			base.TransactionType = (short)12;
			base.IOType = 4;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
