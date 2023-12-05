using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class PurchaseReturnDispatchTransactionLineDto : ProductTransactionLineDto
{
	public PurchaseReturnDispatchTransactionLineDto()
	{
		TransactionType = 6;
		TransactionTypeName = "Satınalma İade İrsaliyesi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }
}
