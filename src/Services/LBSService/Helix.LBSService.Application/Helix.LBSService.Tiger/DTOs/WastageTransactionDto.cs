namespace Helix.LBSService.Tiger.DTOs
{ 
	public class WastageTransactionDto : ProductTransactionDto
	{
		public IList<WastageTransactionLineDto> Lines { get; set; }

		public WastageTransactionDto()
		{
			base.TransactionType = 11;
			base.IOType = 4;

			Lines = new List<WastageTransactionLineDto>();
		}
	}
	public class WastageTransactionLineDto : ProductTransactionLineDto
	{
		public WastageTransactionLineDto()
		{
			TransactionType = 11;
			base.IOType = 4;

		}
	}
}
