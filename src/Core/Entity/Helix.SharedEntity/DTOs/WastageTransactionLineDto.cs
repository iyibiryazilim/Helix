using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class WastageTransactionLineDto: ProductTransactionLineDto
{
	public WastageTransactionLineDto()
	{
		TransactionType = 11;
		TransactionTypeName = "Fire Fişi";
	}
}
