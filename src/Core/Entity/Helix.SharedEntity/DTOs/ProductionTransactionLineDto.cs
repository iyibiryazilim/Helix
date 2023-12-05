using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs;

public class ProductionTransactionLineDto : ProductTransactionLineDto
{
	public ProductionTransactionLineDto()
	{
		TransactionType = 13;
		TransactionTypeName = "Üretimden Giriş Fişi";
		SeriLotTransactions = new List<SeriLotTransaction>();

	}
	public IList<SeriLotTransaction> SeriLotTransactions { get; set; }
}
