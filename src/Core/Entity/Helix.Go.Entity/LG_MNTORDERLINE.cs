namespace Helix.Go.Entity;

public class LG_MNTORDERLINE
{
	public int LOGICALREF { get; set; } = default;
	public int ORDERFICHEREF { get; set; } = default;
	public short TMPLGROUPNR { get; set; } = default;
	public string TMPLCODE { get; set; } = string.Empty;
	public string TMPLNAME { get; set; } = string.Empty;
	public string TMPLDEF { get; set; } = string.Empty;
	public double TMPLDURATION { get; set; } = default;
	public short TMPLDURATIONTYPE { get; set; } = default;
	public int ITEMREF { get; set; } = default;
	public int VARIANTREF { get; set; } = default;
	public double AMOUNT { get; set; } = default;
	public int UOMREF { get; set; } = default;
	public int USREF { get; set; } = default;
	public double UINFO1 { get; set; } = default;
	public double UINFO2 { get; set; } = default;
	public double UINFO3 { get; set; } = default;
	public double UINFO4 { get; set; } = default;
	public double UINFO5 { get; set; } = default;
	public double UINFO6 { get; set; } = default;
	public double UINFO7 { get; set; } = default;
	public double UINFO8 { get; set; } = default;
	public short USAGESLIP { get; set; } = default;
	public short BRANCH { get; set; } = default;
	public short DEPARTMENT { get; set; } = default;
	public short FACTORYNR { get; set; } = default;
	public short SOURCEINDEX { get; set; } = default;
	public string SPECODE { get; set; } = string.Empty;
	public short STATUS { get; set; } = default;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public int WFSTATUS { get; set; } = default;
	public short LINENO_ { get; set; } = default;
	public int PERREF { get; set; } = default;
	public DateTime FICHEDATE { get; set; } = default;
	public int PROJECTREF { get; set; } = default;
	public string GUID { get; set; } = string.Empty;
	public short CANCELLED { get; set; } = default;
	public double OVERLAPPER { get; set; } = default;
}
