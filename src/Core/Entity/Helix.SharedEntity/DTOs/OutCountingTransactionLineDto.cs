using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class OutCountingTransactionLineDto : ProductTransactionLineDto
{
	public OutCountingTransactionLineDto()
	{
		TransactionType = 51;
		TransactionTypeName = "Sayım Eksiği Fişi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }
}
