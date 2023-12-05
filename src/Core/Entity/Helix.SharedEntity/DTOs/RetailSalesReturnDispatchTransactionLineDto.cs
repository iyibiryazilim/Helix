using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class RetailSalesReturnDispatchTransactionLineDto : ProductTransactionLineDto
{
	public RetailSalesReturnDispatchTransactionLineDto()
	{
		TransactionType = 2;
		TransactionTypeName = "Perakende Satış İade İrsaliyesi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }
}
