namespace Helix.Go.Entity;

public class LG_WORKSTAT
{
	public int LOGICALREF { get; set; } = default;
	public string CODE { get; set; } = string.Empty;
	public string NAME { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public short FACTORYDIVNR { get; set; } = default;
	public short FACTORYNR { get; set; } = default;
	public int CALENDARREF { get; set; } = default;
	public short APPROVED { get; set; } = default;
	public double OPERATIONTIME { get; set; } = default;
	public double HOURLYSTDCOST { get; set; } = default;
	public double HOURLYSTDRPCOST { get; set; } = default;
	public int ACCOUNTREF { get; set; } = default;
	public int CENTERREF { get; set; } = default;
	public short ACTIVE { get; set; } = default;
	public short CAPIBLOCK_CREATEDBY { get; set; } = default;
	public DateTime CAPIBLOCK_CREADEDDATE { get; set; } = default;
	public short CAPIBLOCK_CREATEDHOUR { get; set; } = default;
	public short CAPIBLOCK_CREATEDMIN { get; set; } = default;
	public short CAPIBLOCK_CREATEDSEC { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDBY { get; set; } = default;
	public DateTime CAPIBLOCK_MODIFIEDDATE { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDHOUR { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDMIN { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDSEC { get; set; } = default;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public short TEXTINC { get; set; } = default;
	public short IMAGEINC { get; set; } = default;
	public int WFSTATUS { get; set; } = default;
	public short ININVENNR { get; set; } = default;
	public short OUTINVENNR { get; set; } = default;
	public int SHFTGRPREF { get; set; } = default;
	public int HOURDIFFACCREF { get; set; } = default;
	public int HOURDIFFCENTER { get; set; } = default;
	public int PAYDIFFACCREF { get; set; } = default;
	public int PAYDIFFCENTER { get; set; } = default;
	public int PROJECTREF { get; set; } = default;
	public string GUID { get; set; } = string.Empty;
	public short CARDTYPE { get; set; } = default;

}
