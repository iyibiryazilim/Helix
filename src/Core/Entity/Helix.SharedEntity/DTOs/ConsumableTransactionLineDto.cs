using Helix.SharedEntity.DTOs.Base;
using Helix.SharedEntity.Models;

namespace Helix.SharedEntity.DTOs
{
	public class ConsumableTransactionLineDto : ProductTransactionLineDto
	{
        public ConsumableTransactionLineDto()
        {
			TransactionType = 12;
			TransactionTypeName = "Sarf Fişi";
			SeriLotTransactions = new List<SeriLotTransaction>();

		}
		public IList<SeriLotTransaction> SeriLotTransactions { get; set; }

	}
}
