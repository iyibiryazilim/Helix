using Helix.LBSService.WebAPI.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Models
{
	public class LG_ProductDevirTransaction : LG_ProductTransaction
	{
		public LG_ProductDevirTransaction()
		{
			TRANSACTIONS = new List<LG_ProductDevirTransactionLine>();
		}
		public IList<LG_ProductDevirTransactionLine> TRANSACTIONS { get; set; }
	}
}
