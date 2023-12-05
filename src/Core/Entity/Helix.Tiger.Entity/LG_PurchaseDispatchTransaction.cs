namespace Helix.Tiger.Entity
{
    public class LG_PurchaseDispatchTransaction : LG_ProductDispatchTransaction
    {
        public LG_PurchaseDispatchTransaction()
        {
            TRANSACTIONS = new List<LG_PurchaseDispatchTransactionLine>();
        }
        public IList<LG_PurchaseDispatchTransactionLine> TRANSACTIONS { get; set; }
    }
}
