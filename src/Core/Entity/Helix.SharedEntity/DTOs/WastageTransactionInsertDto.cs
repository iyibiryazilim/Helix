using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class WastageTransactionInsertDto : ProductTransactionDto
{
	public WastageTransactionInsertDto()
	{
		TransactionType = 11;
		TransactionTypeName = "Fire Fişi";
		Lines = new List<WastageTransactionLineDto>();
	}
	public IList<WastageTransactionLineDto> Lines { get; set; }
}
