namespace Helix.LBSService.WebAPI.DTOs
{

	public class TransferTransactionDto : ProductTransactionDto
	{
		public IList<TransferTransactionLineDto> Lines { get; set; }

		public TransferTransactionDto()
		{
			TransactionType = 25;
			IOType = 3;

			Lines = new List<TransferTransactionLineDto>();
		}
	}
	public class TransferTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public TransferTransactionLineDto()
		{
			TransactionType = 25;
			IOType = 3;

			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
