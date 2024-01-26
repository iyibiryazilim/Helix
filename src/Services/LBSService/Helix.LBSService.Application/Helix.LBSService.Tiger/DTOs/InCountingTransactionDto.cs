namespace Helix.LBSService.Tiger.DTOs
{
	public class InCountingTransactionDto : ProductTransactionDto
	{
		public IList<InCountingTransactionLineDto> Lines { get; set; }

		public InCountingTransactionDto()
		{
			base.TransactionType = 50;
			base.IOType = 1;

			Lines = new List<InCountingTransactionLineDto>();
		}
	}
	public class InCountingTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public InCountingTransactionLineDto()
		{
			base.TransactionType = (short)50;
			base.IOType = 1;

			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
