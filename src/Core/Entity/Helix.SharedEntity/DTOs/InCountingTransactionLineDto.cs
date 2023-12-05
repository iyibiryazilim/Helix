using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class InCountingTransactionLineDto : ProductTransactionLineDto
{
	public InCountingTransactionLineDto()
	{
		TransactionType = 50;
		TransactionTypeName = "Sayım Fazlası Fişi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }
}
