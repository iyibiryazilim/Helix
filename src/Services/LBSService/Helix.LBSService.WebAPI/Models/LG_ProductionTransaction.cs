using Helix.LBSService.WebAPI.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Models
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
