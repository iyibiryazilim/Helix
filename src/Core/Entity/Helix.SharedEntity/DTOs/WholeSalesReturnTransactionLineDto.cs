using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class WholeSalesReturnTransactionLineDto : ProductTransactionLineDto
{
	public WholeSalesReturnTransactionLineDto()
	{
		TransactionType = 3;
		TransactionTypeName = "Toptan Satış İade İrsaliyesi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }
}
