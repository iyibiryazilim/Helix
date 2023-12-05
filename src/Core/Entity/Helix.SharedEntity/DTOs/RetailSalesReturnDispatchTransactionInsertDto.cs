using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class RetailSalesReturnDispatchTransactionInsertDto : ProductTransactionDto
{
	public RetailSalesReturnDispatchTransactionInsertDto()
	{
		TransactionType = 2;
		TransactionTypeName = "Perakende Satış İade İrsaliyesi";
		Lines = new List<RetailSalesReturnDispatchTransactionLineDto>();
	}
	public IList<RetailSalesReturnDispatchTransactionLineDto> Lines { get; set; }
}
