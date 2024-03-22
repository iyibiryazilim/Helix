using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Models
{
	public class LG_ProductionTransaction : LG_ProductTransaction
	{
		public LG_ProductionTransaction()
		{
			TRANSACTIONS = new List<LG_ProductionTransactionLine>();
		}

		public IList<LG_ProductionTransactionLine> TRANSACTIONS { get; set; }
	}
}