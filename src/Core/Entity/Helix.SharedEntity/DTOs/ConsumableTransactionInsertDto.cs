using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs
{
	public class ConsumableTransactionInsertDto : ProductTransactionDto
	{
        public ConsumableTransactionInsertDto()
		{
			TransactionType = 12;
			TransactionTypeName = "Sarf Fişi";
			Lines = new List<ConsumableTransactionLineDto>();
        } 
        public IList<ConsumableTransactionLineDto> Lines { get; set; }

    }
}
