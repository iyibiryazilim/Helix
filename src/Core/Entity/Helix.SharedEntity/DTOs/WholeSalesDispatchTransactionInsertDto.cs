using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class WholeSalesDispatchTransactionInsertDto : ProductTransactionDto
{
	public WholeSalesDispatchTransactionInsertDto()
	{
		TransactionType = 8;
		TransactionTypeName = "Toptan Satış İrsaliyesi";
		Lines = new List<WholeSalesDispatchTransactionLineDto>();
	}
	public IList<WholeSalesDispatchTransactionLineDto> Lines { get; set; }
}
