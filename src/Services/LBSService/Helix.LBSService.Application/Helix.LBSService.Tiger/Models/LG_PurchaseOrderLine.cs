﻿using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Models
{
	public class LG_PurchaseOrderLine : LG_OrderLine
	{
		public double VAT_AMOUNT { get; set; }
		public double VAT_BASE { get; set; }
		public double TOTAL_NET { get; set; }
		public int CURR_TRANSACTIN { get; set; }
		public double EXCLINE_PRICE { get; set; }
		public int EXCLINE_TOTAL { get; set; }
		public double EXCLINE_VAT_AMOUNT { get; set; }
		public int EXCLINE_VAT_MATRAH { get; set; }
		public int EXCLINE_LINE_NET { get; set; }
		public double ORG_PRICE { get; set; }
	}
}