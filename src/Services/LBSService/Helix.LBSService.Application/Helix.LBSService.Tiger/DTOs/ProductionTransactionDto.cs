namespace Helix.LBSService.Tiger.DTOs
{

	public class ProductionTransactionDto : ProductTransactionDto
	{
		public IList<ProductionTransactionLineDto> Lines { get; set; }

		public ProductionTransactionDto()
		{
			base.TransactionType = 13;
			base.IOType = 1;

			Lines = new List<ProductionTransactionLineDto>();
		}
	}
	public class ProductionTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public ProductionTransactionLineDto()
		{
			base.TransactionType = (short)13;
			base.IOType = 1;

			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
