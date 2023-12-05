using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class PurchaseReturnDispatchTransactionInsertDto : ProductTransactionDto
{
	public PurchaseReturnDispatchTransactionInsertDto()
	{
		TransactionType = 1;
		TransactionTypeName = "Satınalma İade İrsaliyesi";
		Lines = new List<PurchaseReturnDispatchTransactionLineDto>();
	}
	public IList<PurchaseReturnDispatchTransactionLineDto> Lines { get; set; }
}
