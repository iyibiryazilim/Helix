namespace Helix.Tiger.Entity.BaseModel
{
    public class LG_Order
    {
        public string NUMBER { get; set; } = "~";
        public DateTime? DATE { get; set; } = default;
        public object? TIME { get; set; }
        public string? DOC_NUMBER { get; set; } = string.Empty;
        public string? ARP_CODE { get; set; } = string.Empty;
        public string GL_CODE { get; set; } = string.Empty;
        public short SOURCE_WH { get; set; } = default;
        public int SOURCE_COST_GRP { get; set; } = default;
        public int RC_RATE { get; set; } = default;
        public string PAYMENT_CODE { get; set; } = string.Empty;
        public int PAYDEFREF { get; set; } = default;
        public short ORDER_STATUS { get; set; } = default;
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
        public int CURRSEL_TOTAL { get; set; } = default;
        public int DATA_REFERENCE { get; set; } = default;
        public int AFFECT_RISK { get; set; } = default;
        public short DEDUCTIONPART1 { get; set; } = default;
        public short DEDUCTIONPART2 { get; set; } = default;
        public short EINVOICE { get; set; } = default;
        public short EINVOICE_PROFILEID { get; set; } = default;
        public Guid GUID { get; set; } = Guid.NewGuid();


        public LG_Order()
        {
            TRANSACTIONS = new List<LG_OrderLine>();
        }

        public IList<LG_OrderLine> TRANSACTIONS { get; set; }
    }
}
