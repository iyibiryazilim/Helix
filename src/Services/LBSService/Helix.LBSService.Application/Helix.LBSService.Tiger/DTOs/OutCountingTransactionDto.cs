namespace Helix.LBSService.Tiger.DTOs
{

	public class OutCountingTransactionDto : ProductTransactionDto
	{
		public IList<OutCountingTransactionLineDto> Lines { get; set; }

		public OutCountingTransactionDto()
		{
			base.TransactionType = 51;
			base.IOType = 4;

			Lines = new List<OutCountingTransactionLineDto>();
		}
	}
	public class OutCountingTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public OutCountingTransactionLineDto()
		{
			base.TransactionType = (short)51;
			base.IOType = 4;

			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
