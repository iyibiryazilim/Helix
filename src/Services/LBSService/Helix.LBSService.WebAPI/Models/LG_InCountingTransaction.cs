using Helix.LBSService.WebAPI.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Models
{
	public class LG_InCountingTransaction : LG_ProductTransaction
	{
		public LG_InCountingTransaction()
		{
			TRANSACTIONS = new List<LG_InCountingTransactionLine>();
		}
		public IList<LG_InCountingTransactionLine> TRANSACTIONS { get; set; }
	}
}
