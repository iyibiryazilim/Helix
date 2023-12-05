using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class OutCountingTransactionInsertDto : ProductTransactionDto
{
	public OutCountingTransactionInsertDto()
	{
		TransactionType = 51;
		TransactionTypeName = "Sayım Eksiği Fişi";
		Lines = new List<OutCountingTransactionLineDto>();
	}
	public IList<OutCountingTransactionLineDto> Lines { get; set; }
}
