using Helix.LBSService.WebAPI.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Models
{
	public class LG_WastageTransaction : LG_ProductTransaction
	{
		public LG_WastageTransaction()
		{
			TRANSACTIONS = new List<LG_WastageTransactionLine>();
		}
		public IList<LG_WastageTransactionLine> TRANSACTIONS { get; set; }
	}
}
