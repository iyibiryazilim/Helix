namespace Helix.LBSService.EventConsumer.Dtos
{
	public class WastageTransactionDto : ProductTransactionDto
	{
		public IList<WastageTransactionLineDto> Lines { get; set; }

		public WastageTransactionDto()
		{
			TransactionType = 11;
			IOType = 4;

			Lines = new List<WastageTransactionLineDto>();
		}
	}
	public class WastageTransactionLineDto : ProductTransactionLineDto
	{
		public WastageTransactionLineDto()
		{
			TransactionType = 11;
			IOType = 4;

		}
	}
}
