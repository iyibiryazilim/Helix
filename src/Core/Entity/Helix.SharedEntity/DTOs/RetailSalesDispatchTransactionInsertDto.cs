using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class RetailSalesDispatchTransactionInsertDto : ProductTransactionDto
{
	public RetailSalesDispatchTransactionInsertDto()
	{
		TransactionType = 7;
		TransactionTypeName = "Perakende Satış İrsaliyesi";
		Lines = new List<RetailSalesDispatchTransactionLineDto>();
	}
	public IList<RetailSalesDispatchTransactionLineDto> Lines { get; set; }
}
