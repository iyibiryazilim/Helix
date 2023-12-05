using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs;

public class ProductionTransactionInsertDto : ProductTransactionDto
{
	public ProductionTransactionInsertDto()
	{
		TransactionType = 13;
		TransactionTypeName = "Üretimden Giriş Fişi";
		Lines = new List<ProductionTransactionLineDto>();
	}
	public IList<ProductionTransactionLineDto> Lines { get; set; }
}
