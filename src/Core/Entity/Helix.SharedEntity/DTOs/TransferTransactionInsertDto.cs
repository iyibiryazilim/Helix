using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class TransferTransactionInsertDto : ProductTransactionDto
{
	public TransferTransactionInsertDto()
	{
		TransactionType = 25;
		TransactionTypeName = "Ambar Fişi";
		Lines = new List<TransferTransactionLineDto>();
	}
	public IList<TransferTransactionLineDto> Lines { get; set; }
}
