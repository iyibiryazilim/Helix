namespace Helix.LBSService.Tiger.Models
{
	public class LG_ProductPurchaseDispatchTransaction : LG_ProductDispatchTransaction
	{
		public LG_ProductPurchaseDispatchTransaction()
		{
			TRANSACTIONS = new List<LG_ProductPurchaseDispatchTransactionLine>();
		}

		public IList<LG_ProductPurchaseDispatchTransactionLine> TRANSACTIONS { get; set; }
	}
}