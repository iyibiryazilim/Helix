namespace Helix.LBSService.Tiger.Models
{
    public class LG_WholeSalesReturnDispatch : LG_ProductSalesDispatchTransaction
    {
        public LG_WholeSalesReturnDispatch()
        {
            TRANSACTIONS = new List<LG_WholeSalesReturnDispatchLine>();
        }
        public new IList<LG_WholeSalesReturnDispatchLine> TRANSACTIONS { get; set; }
    }
}
