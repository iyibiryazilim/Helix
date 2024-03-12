namespace Helix.LBSService.Tiger.Models
{
	public class LG_Current
	{
		public int ACCOUNT_TYPE { get; set; } = 3;
        public string CODE { get; set; } = string.Empty;
        public string TITLE { get; set; } = string.Empty;
		public string AUXIL_CODE { get; set; } = string.Empty;
		public string ADDRESS1 { get; set; } = string.Empty;
		public string ADDRESS2 { get; set; } = string.Empty;
		public string DISTRICT_CODE { get; set; } = string.Empty;
		public string DISTRICT { get; set; } = string.Empty;
		public string TOWN_CODE { get; set; } = string.Empty;
		public string TOWN { get; set; } = string.Empty;
		public string CITY_CODE { get; set; } = string.Empty;
		public string CITY { get; set; } = string.Empty;
		public string COUNTRY_CODE { get; set; } = string.Empty;
		public string COUNTRY { get; set; } = string.Empty; 
		public string TELEPHONE1 { get; set; } = string.Empty;
		public string TAX_ID { get; set; } = string.Empty;
		public string TAX_OFFICE { get; set; } = string.Empty;
		public string PAYMENT_CODE { get; set; } = string.Empty;
		public string E_MAIL { get; set; } = string.Empty;
		public int CREATED_BY { get; set; } = default; 
		public DateTime DATE_CREATED { get; set; } = DateTime.Now;
		public int HOUR_CREATED { get; set; } = DateTime.Now.Hour;
		public int MIN_CREATED { get; set; } = DateTime.Now.Minute;
		public int SEC_CREATED { get; set; } = DateTime.Now.Second;
		public short MODIFIED_BY { get; set; } = default;
		public DateTime DATE_MODIFIED { get; set; }
		public int HOUR_MODIFIED { get; set; } = default;
		public int MIN_MODIFIED { get; set; } = default;
		public int SEC_MODIFIED { get; set; } = default;
		public int NOTES { get; set; } = default;
		public int CREDIT_TYPE { get; set; } = default;
		public int RISKFACT_CHQ { get; set; } = default;
		public int RISKFACT_PROMNT { get; set; } = default;
		public string GL_CODE { get; set; } = string.Empty;
		public string LOGOID { get; set; } = string.Empty;
		public int IMG2INC { get; set; } = default;
		public int INVOICE_PRNT_CNT { get; set; } = default;
		public string PARENTCLCODE { get; set; } = string.Empty;
		public int PURCHBRWS { get; set; } = default;
		public int SALESBRWS { get; set; } = default;
		public int IMPBRWS { get; set; } = default;
		public int EXPBRWS { get; set; } = default;
		public int FINBRWS { get; set; } = default;
		public int COLLATRLRISK_TYPE { get; set; } = default;
		public int ACCEPT_EINV { get; set; } = default;
		public int ACCEPT_DESP { get; set; } = default;

		public int PROFILE_ID { get; set; } = default;
		public int EARCHIVE_SEND_MODE { get; set; } = default;
		public string TITLE2 { get; set; } = string.Empty;
		public string POST_LABEL { get; set; } = string.Empty;
		public string SENDER_LABEL { get; set; } = string.Empty; 
		public int PROFILEID_DESP { get; set; } = default;
		public string POST_LABEL_CODE_DESP { get; set; } = string.Empty;
		public string SENDER_LABEL_CODE_DESP { get; set; } = string.Empty;
		public Guid GUID { get; set; } = Guid.NewGuid();
		public int DATA_REFERENCE { get; set; } = default;

		public int DISP_PRINT_CNT { get; set; } = default; 
		public int ORD_PRINT_CNT { get; set; } = default; 
	}
}
