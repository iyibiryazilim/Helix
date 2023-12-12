namespace Helix.LBSService.Tiger.Models
{
    public class LG_RetailSalesReturnDispatchTransaction : LG_ProductSalesDispatchTransaction
    {
        public LG_RetailSalesReturnDispatchTransaction()
        {
            TRANSACTIONS = new List<LG_RetailSalesReturnDispatchTransactionLine>();
        }
        public new IList<LG_RetailSalesReturnDispatchTransactionLine> TRANSACTIONS { get; set; }
    }
}
