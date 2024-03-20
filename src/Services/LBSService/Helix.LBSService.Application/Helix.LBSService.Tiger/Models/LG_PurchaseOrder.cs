using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Models
{
	public class LG_PurchaseOrder : LG_Order
    {   
        public LG_PurchaseOrder()
        {
            TRANSACTIONS = new List<LG_PurchaseOrderLine>();
        }
        public new IList<LG_PurchaseOrderLine> TRANSACTIONS { get; set; }
    }
}
