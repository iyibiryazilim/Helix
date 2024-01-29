namespace Helix.LBSService.WebAPI.DTOs
{

	public class ProductionTransactionDto : ProductTransactionDto
	{
		public IList<ProductionTransactionLineDto> Lines { get; set; }

		public ProductionTransactionDto()
		{
			TransactionType = 13;
			IOType = 1;

			Lines = new List<ProductionTransactionLineDto>();
		}
	}
	public class ProductionTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public ProductionTransactionLineDto()
		{
			TransactionType = 13;
			IOType = 1;

			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
