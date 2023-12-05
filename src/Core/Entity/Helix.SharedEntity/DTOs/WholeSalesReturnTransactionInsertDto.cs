using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class WholeSalesReturnTransactionInsertDto : ProductTransactionDto
{
	public WholeSalesReturnTransactionInsertDto()
	{
		TransactionType = 3;
		TransactionTypeName = "Toptan Satış İade İrsaliyesi";
		Lines = new List<WholeSalesReturnTransactionLineDto>();
	}
	public IList<WholeSalesReturnTransactionLineDto> Lines { get; set; }
}
