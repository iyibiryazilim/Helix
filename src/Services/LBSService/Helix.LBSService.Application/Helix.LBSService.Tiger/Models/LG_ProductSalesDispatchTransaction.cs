namespace Helix.LBSService.Tiger.Models
{
    public class LG_ProductSalesDispatchTransaction : LG_ProductDispatchTransaction
    {
        public LG_ProductSalesDispatchTransaction()
        {
            TRANSACTIONS = new List<LG_ProductSalesDispatchTransactionLine>();
        }
        public IList<LG_ProductSalesDispatchTransactionLine> TRANSACTIONS { get; set; }
    }
}
