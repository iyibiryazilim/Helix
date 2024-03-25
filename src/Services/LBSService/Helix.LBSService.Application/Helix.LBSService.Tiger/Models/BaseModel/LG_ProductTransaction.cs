namespace Helix.LBSService.Tiger.Models.BaseModel
{
	public class LG_ProductTransaction
	{
		public string EmployeeOid { get; set; } = string.Empty;
		public short GROUP { get; set; } = default;
		public short TYPE { get; set; } = default;
		public string NUMBER { get; set; } = "~";
		public DateTime DATE { get; set; } = DateTime.Now;
		public DateTime DATE_CREATED { get; set; } = DateTime.Now.Date;
		public int HOUR_CREATED { get; set; } = DateTime.Now.Hour;
		public int MIN_CREATED { get; set; } = DateTime.Now.Minute;
		public int SEC_CREATED { get; set; } = DateTime.Now.Second;
		public object? TIME { get; set; }
		public int MODIFIED_BY { get; set; } = default;
		public DateTime DATE_MODIFIED { get; set; }
		public int HOUR_MODIFIED { get; set; } = default;
		public int MIN_MODIFIED { get; set; } = default;
		public int SEC_MODIFIED { get; set; } = default;
		public int SHIP_TIME { get; set; } = default;
		public int DOC_TIME { get; set; } = default;
		public short SOURCEINDEX { get; set; } = default;
		public int RC_RATE { get; set; } = default;
		public short CREATED_BY { get; set; } = 1;
		public int CURRSEL_TOTALS { get; set; } = default;
		public string DOC_TRACK_NR { get; set; } = string.Empty;
		public int SOURCE_WH { get; set; } = default;
		public short PORDER_TYPE { get; set; } = default;
		public string SOURCE_WSCODE { get; set; } = string.Empty;
		public string SPO_DETAIL_CODE { get; set; } = string.Empty;
		public int SRCPOLN_REFERENCE { get; set; } = default;
		public int SOURCE_COST_GRP { get; set; } = default;
		public int DATA_REFERENCE { get; set; } = default;
		public DateTime SHIP_DATE { get; set; } = default;
		public DateTime DOC_DATE { get; set; } = default;
		public string DOC_NUMBER { get; set; } = string.Empty;
		public Guid GUID { get; set; } = Guid.NewGuid();
		public short EBOOK_DOCTYPE { get; set; }
	}
}