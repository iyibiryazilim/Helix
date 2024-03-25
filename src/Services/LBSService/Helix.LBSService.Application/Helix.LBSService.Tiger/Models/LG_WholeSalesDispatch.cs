namespace Helix.LBSService.Tiger.Models
{
	public class LG_WholeSalesDispatchTransaction : LG_ProductSalesDispatchTransaction
	{
		public LG_WholeSalesDispatchTransaction()
		{
			TRANSACTIONS = new List<LG_WholeSalesDispatchLine>();
		}

		public new IList<LG_WholeSalesDispatchLine> TRANSACTIONS { get; set; }
	}
}