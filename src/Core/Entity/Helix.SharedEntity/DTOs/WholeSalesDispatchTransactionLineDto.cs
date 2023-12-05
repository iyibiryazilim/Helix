using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class WholeSalesDispatchTransactionLineDto : ProductTransactionLineDto
{
	public WholeSalesDispatchTransactionLineDto()
	{
		TransactionType = 8;
		TransactionTypeName = "Toptan Satış İrsaliyesi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }
}
