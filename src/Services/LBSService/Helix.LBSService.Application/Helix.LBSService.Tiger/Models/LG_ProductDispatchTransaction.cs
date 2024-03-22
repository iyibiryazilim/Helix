using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Models
{
	public class LG_ProductDispatchTransaction : LG_ProductTransaction
	{
		public string ARP_CODE { get; set; } = string.Empty;
		public string GL_CODE { get; set; } = string.Empty;
		public double TOTAL_DISCOUNTED { get; set; } = default;
		public double TOTAL_VAT { get; set; } = default;
		public double TOTAL_GROSS { get; set; } = default;
		public double TOTAL_NET { get; set; } = default;
		public double RC_NET { get; set; } = default;
		public string PAYMENT_CODE { get; set; } = string.Empty;
		public int GRPFIRMTRANS { get; set; } = default;
		public int DEDUCTIONPART1 { get; set; } = default;
		public int DEDUCTIONPART2 { get; set; } = default;
		public int DISP_STATUS { get; set; } = default;
		public string TOTAL_NET_STR { get; set; } = string.Empty;
		public int AFFECT_RISK { get; set; } = default;
		public int EDESPATCH { get; set; } = default;
		public int EDESPATCH_PROFILEID { get; set; } = default;
		public int EINVOICE { get; set; } = default;
		public int EINVOICE_PROFILEID { get; set; } = default;
		public string EINVOICE_DRIVERNAME1 { get; set; } = string.Empty;
		public string EINVOICE_DRIVERNAME2 { get; set; } = string.Empty;
		public string EINVOICE_DRIVERSURNAME1 { get; set; } = string.Empty;
		public string EINVOICE_DRIVERSURNAME2 { get; set; } = string.Empty;
		public string EINVOICE_DRIVERTCKNO1 { get; set; } = string.Empty;
		public string EINVOICE_DRIVERTCKNO2 { get; set; } = string.Empty;
		public string EINVOICE_PLATENUM1 { get; set; } = string.Empty;
		public string EINVOICE_PLATENUM2 { get; set; } = string.Empty;
		public string SHIPPING_AGENT { get; set; } = string.Empty;
		public string SHIPLOC_CODE { get; set; } = string.Empty;
		public string SHIPLOC_DEF { get; set; } = string.Empty;
		public string NOTES1 { get; set; } = string.Empty;
		public string NOTES2 { get; set; } = string.Empty;
		public string NOTES3 { get; set; } = string.Empty;
		public string NOTES4 { get; set; } = string.Empty;
		public string NOTES5 { get; set; } = string.Empty;
	}
}