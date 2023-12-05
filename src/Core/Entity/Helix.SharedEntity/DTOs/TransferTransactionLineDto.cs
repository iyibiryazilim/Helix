using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class TransferTransactionLineDto : ProductTransactionLineDto
{
	public TransferTransactionLineDto()
	{
		TransactionType = 25;
		TransactionTypeName = "Ambar Fişi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }
}
