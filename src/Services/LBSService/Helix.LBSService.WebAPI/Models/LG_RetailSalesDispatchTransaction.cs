namespace Helix.LBSService.WebAPI.Models
{
	public class LG_RetailSalesDispatchTransaction : LG_ProductDispatchTransaction
	{
		public LG_RetailSalesDispatchTransaction()
		{
			TRANSACTIONS = new List<LG_RetailSalesDispatchTransactionLine>();
		}
		public IList<LG_RetailSalesDispatchTransactionLine> TRANSACTIONS { get; set; }
	}
}
