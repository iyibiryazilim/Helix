﻿namespace Helix.LBSService.Tiger.Models.BaseModel
{
	public class LG_OrderLine
	{
		public short TYPE { get; set; } = default;
		public string MASTER_CODE { get; set; } = string.Empty;
		public string GL_CODE1 { get; set; } = string.Empty;
		public string GL_CODE2 { get; set; } = string.Empty;
		public double QUANTITY { get; set; } = default;
		public double PRICE { get; set; } = default;
		public double TOTAL { get; set; } = default;
		public string TRANS_DESCRIPTION { get; set; } = string.Empty;
		public double DISCOUNT_RATE { get; set; } = default;
		public int VAT_RATE { get; set; } = default;
		public string UNIT_CODE { get; set; } = string.Empty;
		public int UNIT_CONV1 { get; set; } = default;
		public int UNIT_CONV2 { get; set; } = default;
		public int UNIT_CONV3 { get; set; } = default;
		public int UNIT_CONV4 { get; set; } = default;
		public int UNIT_CONV5 { get; set; } = default;
		public int UNIT_CONV6 { get; set; } = default;
		public int UNIT_CONV7 { get; set; } = default;
		public int UNIT_CONV8 { get; set; } = default;
		public short ORDER_CLOSED { get; set; } = default;
		public string VARIANTCODE { get; set; } = string.Empty;
		public DateTime DUE_DATE { get; set; }
		public int RC_XRATE { get; set; } = default;
		public short SOURCE_WH { get; set; } = default;
		public int SOURCE_COST_GRP { get; set; } = default;
		public int DATA_REFERENCE { get; set; } = default;
		public short MULTI_ADD_TAX { get; set; } = default;
		public int EDT_CURR { get; set; } = default;
		public double EDT_PRICE { get; set; } = default;
		public DateTime ORG_DUE_DATE { get; set; }
		public double ORG_QUANTITY { get; set; } = default;
		public string PRODUCER_CODE { get; set; } = string.Empty;
		public string GTIP_CODE { get; set; } = string.Empty;
		public Guid GUID { get; set; } = Guid.NewGuid();
	}
}