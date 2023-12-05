namespace Helix.Tiger.Entity
{
	public class LG_SeriLotTransaction
    {
		public int SOURCE_MT_REFERENCE { get; set; } = default;
		public int SOURCE_SLT_REFERENCE { get; set; } = default;
		public DateTime DATE { get; set; } = DateTime.Now;
		public DateTime DATE_CREATED { get; set; } = DateTime.Now.Date;
		public int HOUR_CREATED { get; set; } = DateTime.Now.Hour;
		public int MIN_CREATED { get; set; } = DateTime.Now.Minute;
		public int SEC_CREATED { get; set; } = DateTime.Now.Second;
		public short IOCODE { get; set; } = default;
		public DateTime DATE_EXPIRED { get; set; }
		public short SL_TYPE { get; set; } = default;
		public int RC_RATE { get; set; } = default;
		public short SOURCE_WH { get; set; } = 1;
		public int CURRSEL_TOTALS { get; set; } = default;
		public string LOCATION_CODE { get; set; } = string.Empty;
		public string DEST_LOCATION_CODE { get; set; } = string.Empty;
		public string SL_CODE { get; set; } = string.Empty;
		public string SL_NAME { get; set; } = string.Empty;
		public string UNIT_CODE { get; set; } = string.Empty;
		public double UNIT_CONV1 { get; set; } = default;
		public double UNIT_CONV2 { get; set; } = default;
		public double QUANTITY { get; set; } = default;
		public double MU_QUANTITY { get; set; } = default;
		public double SOURCE_QUANTITY { get; set; } = default;
	}
}
