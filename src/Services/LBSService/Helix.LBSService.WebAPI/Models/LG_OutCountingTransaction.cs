using Helix.LBSService.WebAPI.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Models
{
	public class LG_OutCountingTransaction : LG_ProductTransaction
	{
		public LG_OutCountingTransaction()
		{
			TRANSACTIONS = new List<LG_OutCountingTransactionLine>();
		}
		public IList<LG_OutCountingTransactionLine> TRANSACTIONS { get; set; }
	}
}
