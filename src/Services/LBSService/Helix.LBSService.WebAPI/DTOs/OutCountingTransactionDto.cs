namespace Helix.LBSService.WebAPI.DTOs
{

	public class OutCountingTransactionDto : ProductTransactionDto
	{
		public IList<OutCountingTransactionLineDto> Lines { get; set; }

		public OutCountingTransactionDto()
		{
			TransactionType = 51;
			IOType = 4;

			Lines = new List<OutCountingTransactionLineDto>();
		}
	}
	public class OutCountingTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public OutCountingTransactionLineDto()
		{
			TransactionType = 51;
			IOType = 4;

			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
