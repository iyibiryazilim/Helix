using Helix.Tiger.Entity.BaseModel;

namespace Helix.Tiger.Entity
{
    public class LG_PurchaseOrder : LG_Order
    {
        public double TOTAL_DISCOUNTED { get; set; }
        public double TOTAL_VAT { get; set; }
        public double TOTAL_GROSS { get; set; }
        public double TOTAL_NET { get; set; }
        public double RC_NET { get; set; }
        public int CURRSEL_DETAILS { get; set; }
        public int CURR_TRANSACTIN { get; set; }
        public double TC_RATE { get; set; }
        public int EXCHINFO_TOTAL_DISCOUNTED { get; set; }
        public double EXCHINFO_TOTAL_VAT { get; set; }
        public int EXCHINFO_GROSS_TOTAL { get; set; }

        public LG_PurchaseOrder()
        {
            TRANSACTIONS = new List<LG_PurchaseOrderLine>();
        }
        public new IList<LG_PurchaseOrderLine> TRANSACTIONS { get; set; }
    }
}
