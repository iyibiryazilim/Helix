using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class PurchaseDispatchTransactionLineDto: ProductTransactionLineDto
{
	public PurchaseDispatchTransactionLineDto()
	{
		TransactionType = 1;
		TransactionTypeName = "Satınalma İrsaliyesi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }
}
