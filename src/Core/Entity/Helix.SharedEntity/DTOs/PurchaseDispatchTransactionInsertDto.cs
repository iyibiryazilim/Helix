using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class PurchaseDispatchTransactionInsertDto : ProductTransactionDto
{
	public PurchaseDispatchTransactionInsertDto()
	{
		TransactionType = 1;
		TransactionTypeName = "Satınalma İrsaliyesi";
		Lines = new List<PurchaseDispatchTransactionLineDto>();
	}
	public IList<PurchaseDispatchTransactionLineDto> Lines { get; set; }
}
