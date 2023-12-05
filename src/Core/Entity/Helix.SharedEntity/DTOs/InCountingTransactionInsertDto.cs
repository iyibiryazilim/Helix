using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs
{
	public class InCountingTransactionInsertDto : ProductTransactionDto
	{
		public InCountingTransactionInsertDto()
		{
			TransactionType = 50;
			TransactionTypeName = "Sayım Fazlası Fişi";
			Lines = new List<InCountingTransactionLineDto>();
		}
		public IList<InCountingTransactionLineDto> Lines { get; set; }
	}
}
