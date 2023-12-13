namespace Helix.LBSService.Tiger.DTOs
{ 
	public class WastageTransactionDto : ProductTransactionDto
	{
		public IList<WastageTransactionLineDto> Lines { get; set; }

		public WastageTransactionDto()
		{
			base.TransactionType = 11;
			base.TransactionTypeName = "Fire Fişi";
			Lines = new List<WastageTransactionLineDto>();
		}
	}
	public class WastageTransactionLineDto : ProductTransactionLineDto
	{
		public WastageTransactionLineDto()
		{
			TransactionType = 11;
			TransactionTypeName = "Fire Fişi";
		}
	}
}
