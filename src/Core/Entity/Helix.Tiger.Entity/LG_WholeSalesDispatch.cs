namespace Helix.Tiger.Entity
{
    public class LG_WholeSalesDispatch : LG_ProductSalesDispatchTransaction
    {
        public LG_WholeSalesDispatch()
        {
            TRANSACTIONS = new List<LG_WholeSalesDispatchLine>();
        }
        public new IList<LG_WholeSalesDispatchLine> TRANSACTIONS { get; set; }
    }
}
