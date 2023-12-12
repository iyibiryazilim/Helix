namespace Helix.LBSService.Tiger.Models
{
    public class LG_PurchaseReturnDispatchTransaction : LG_ProductPurchaseDispatchTransaction
    {
        public LG_PurchaseReturnDispatchTransaction()
        {
            TRANSACTIONS = new List<LG_PurchaseReturnDispatchTransactionLine>();
        }
        public new IList<LG_PurchaseReturnDispatchTransactionLine> TRANSACTIONS { get; set; }
    }
}
