using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class RetailSalesDispatchTransactionLineDto : ProductTransactionLineDto
{
	public RetailSalesDispatchTransactionLineDto()
	{
		TransactionType = 7;
		TransactionTypeName = "Perakende Satış İrsaliyesi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }

}
