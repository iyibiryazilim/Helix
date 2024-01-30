namespace Helix.LBSService.WebAPI.Models
{
	public class LG_SalesPurchaseDispatchTransaction : LG_ProductDispatchTransaction
	{
		public LG_SalesPurchaseDispatchTransaction()
		{
			TRANSACTIONS = new List<LG_SalesDispatchTransactionLine>();
		}
		public IList<LG_SalesDispatchTransactionLine> TRANSACTIONS { get; set; }
	}
}
