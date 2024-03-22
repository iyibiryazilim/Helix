using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Models
{
	public class LG_ConsumableTransaction : LG_ProductTransaction
	{
		public LG_ConsumableTransaction()
		{
			TRANSACTIONS = new List<LG_ConsumableTransactionLine>();
		}

		public IList<LG_ConsumableTransactionLine> TRANSACTIONS { get; set; }
	}
}