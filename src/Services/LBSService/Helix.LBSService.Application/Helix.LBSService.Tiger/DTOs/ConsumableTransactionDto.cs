namespace Helix.LBSService.Tiger.DTOs
{
	public class ConsumableTransactionDto : ProductTransactionDto
	{
		public IList<ConsumableTransactionLineDto> Lines { get; set; }

		public ConsumableTransactionDto()
		{
			base.TransactionType = 12;
			base.TransactionTypeName = "Sarf Fişi";
			Lines = new List<ConsumableTransactionLineDto>();
		}
	}
	public class ConsumableTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public ConsumableTransactionLineDto()
		{
			base.TransactionType = (short)12;
			base.TransactionTypeName = "Sarf Fişi";
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
