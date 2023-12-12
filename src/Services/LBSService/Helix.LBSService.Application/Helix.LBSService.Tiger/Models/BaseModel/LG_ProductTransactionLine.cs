namespace Helix.LBSService.Tiger.Models.BaseModel
{
	public class LG_ProductTransactionLine
    {
        public LG_ProductTransactionLine()
        {
			SLTRANS = new List<LG_SeriLotTransaction>();

		}
		public IList<LG_SeriLotTransaction> SLTRANS { get; set; }

		/// <summary>
		/// LOGICALREF
		/// </summary>
		public int INTERNAL_REFERENCE { get; set; }

		/// <summary>
		/// LINETYPE
		/// </summary>
		public int TYPE { get; set; } = default;

		/// <summary>
		/// ITEMREF - Malzeme Kodudur
		/// </summary>
		public string MASTER_CODE { get; set; } = string.Empty;

		/// <summary>
		/// Sipariş Miktarı
		/// </summary>
		public double QUANTITY { get; set; } = default;
		public string ITEM_CODE { get; set; } = string.Empty;
		public short LINE_TYPE { get; set; } = default;
		public short PRORD_TYPE { get; set; } = default;
		public short SOURCEINDEX { get; set; } = default;
		public int SOURCECOSTGRP { get; set; } = default;
		public string LINE_NUMBER { get; set; } = string.Empty;
		public int RC_XRATE { get; set; } = default;
		public string UNIT_CODE { get; set; } = string.Empty;
		public int UNIT_CONV1 { get; set; } = default;
		public int UNIT_CONV2 { get; set; } = default;
		public int DATA_REFERENCE { get; set; } = default;
		public short EU_VAT_STATUS { get; set; } = default;
		public int EDT_CURR { get; set; } = default;
		public string GL_CODE2 { get; set; } = string.Empty;
		public string DESCRIPTION { get; set; } = string.Empty;
	}
}
