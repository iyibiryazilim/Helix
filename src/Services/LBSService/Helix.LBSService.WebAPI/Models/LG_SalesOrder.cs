using Helix.LBSService.WebAPI.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Models
{
	public class LG_SalesOrder : LG_Order
	{
		public LG_SalesOrder()
		{
			TRANSACTIONS = new List<LG_SalesOrderLine>();
		}
		public new IList<LG_SalesOrderLine> TRANSACTIONS { get; set; }
	}
}
