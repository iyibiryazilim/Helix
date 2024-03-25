namespace Helix.LBSService.WebAPI.DTOs
{
	public class InCountingTransactionDto : ProductTransactionDto
	{
		public IList<InCountingTransactionLineDto> Lines { get; set; }

		public InCountingTransactionDto()
		{
			TransactionType = 50;
			IOType = 1;

			Lines = new List<InCountingTransactionLineDto>();
		}
	}

	public class InCountingTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public InCountingTransactionLineDto()
		{
			TransactionType = 50;
			IOType = 1;

			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}