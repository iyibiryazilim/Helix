namespace Helix.LBSService.Tiger.DTOs
{

	public class TransferTransactionDto : ProductTransactionDto
	{
		public IList<TransferTransactionLineDto> Lines { get; set; }

		public TransferTransactionDto()
		{
			base.TransactionType = 25;
			base.IOType = 3;

			Lines = new List<TransferTransactionLineDto>();
		}
	}
	public class TransferTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public TransferTransactionLineDto()
		{
			base.TransactionType = (short)25;
			base.IOType = 3;

			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
