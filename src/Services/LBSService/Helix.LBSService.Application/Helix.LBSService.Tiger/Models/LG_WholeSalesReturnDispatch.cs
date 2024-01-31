namespace Helix.LBSService.Tiger.Models
{
    public class LG_WholeSalesReturnDispatchTransaction : LG_ProductSalesDispatchTransaction
    {
        public LG_WholeSalesReturnDispatchTransaction()
        {
            TRANSACTIONS = new List<LG_WholeSalesReturnDispatchLine>();
        }
        public new IList<LG_WholeSalesReturnDispatchLine> TRANSACTIONS { get; set; }
    }
}
