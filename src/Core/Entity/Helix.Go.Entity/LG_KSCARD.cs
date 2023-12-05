namespace Helix.Go.Entity;

public class LG_KSCARD
{
	public int LOGICALREF { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string NAME { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public string EXPLAIN { get; set; } = string.Empty;
	public string ADDR1 { get; set; } = string.Empty;
	public string ADDR2 { get; set; } = string.Empty;
	public short CAPIBLOCK_CREATEDBY { get; set; } = default;
	public DateTime CAPIBLOCK_CREADEDDATE { get; set; }
	public short CAPIBLOCK_CREATEDHOUR { get; set; } = default;
	public short CAPIBLOCK_CREATEDMIN { get; set; } = default;
	public short CAPIBLOCK_CREATEDSEC { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDBY { get; set; } = default;
	public DateTime CAPIBLOCK_MODIFIEDDATE { get; set; }
	public short CAPIBLOCK_MODIFIEDHOUR { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDMIN { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDSEC { get; set; } = default;
	public short ACTIVE { get; set; } = default;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; }
	public int WFSTATUS { get; set; }
	public short CCURRENCY { get; set; } = default;
	public short CURRATETYPE { get; set; } = default;
	public short FIXEDCURRTYPE { get; set; } = default;
	public short USEDINPERIODS { get; set; } = default;
	public string GUID { get; set; } = string.Empty;
	public short BRANCH { get; set; } = default;
}
