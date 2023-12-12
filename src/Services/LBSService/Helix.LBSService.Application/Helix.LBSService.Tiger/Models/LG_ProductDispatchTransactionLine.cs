using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Models
{
	public class LG_ProductDispatchTransactionLine : LG_ProductTransactionLine
	{
		public LG_ProductDispatchTransactionLine()
		{
			SLTRANS = new List<LG_SeriLotTransaction>();
		}
		public IList<LG_SeriLotTransaction> SLTRANS { get; set; }
		public int ORDER_REFERENCE { get; set; } = default;
		public string GL_CODE1 { get; set; } = string.Empty;
		public double PRICE { get; set; } = default;
		public double TOTAL { get; set; } = default;
		public int CURR_PRICE { get; set; } = default;
		public int PC_PRICE { get; set; } = default;
		public int VAT_RATE { get; set; } = default;
		public double VAT_AMOUNT { get; set; } = default;
		public double VAT_BASE { get; set; } = default;
		public double TOTAL_NET { get; set; } = default;
		public int DIST_ORD_REFERENCE { get; set; } = default;
		public double PR_RATE { get; set; } = default;
		public int MULTI_ADD_TAX { get; set; } = default;
		public double EDT_PRICE { get; set; } = default;
		public int MONTH { get; set; } = default;
		public int YEAR { get; set; } = default;
		public string PRCLISTCODE { get; set; } = string.Empty;
		public int PRCLISTTYPE { get; set; } = default;
		public Guid GUID { get; set; } = Guid.NewGuid();
		public string MASTER_DEF { get; set; } = string.Empty;
		public string MASTER_DEF3 { get; set; } = string.Empty;
		public int FOREIGN_TRADE_TYPE { get; set; } = default;
		public int DISTRIBUTION_TYPE_WHS { get; set; } = default;
		public int DISTRIBUTION_TYPE_FNO { get; set; } = default;
		public int SOURCE_REFERENCE { get; set; } = default;
	}
}
