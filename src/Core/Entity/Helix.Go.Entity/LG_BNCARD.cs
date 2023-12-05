namespace Helix.Go.Entity;

public class LG_BNCARD
{
	#region Properties
	public int? LOGICALREF { get; set; }
	public short? ACTIVE { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string DEFINITION_ { get; set; } = string.Empty;
	public string BRANCH { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public string BRANCHNO { get; set; } = string.Empty;
	public string ADDR1 { get; set; } = string.Empty;
	public string ADDR2 { get; set; } = string.Empty;
	public string CITY { get; set; } = string.Empty;
	public string COUNTRY { get; set; } = string.Empty;
	public string POSTCODE { get; set; } = string.Empty;
	public string TELNRS1 { get; set; } = string.Empty;
	public string TELNRS2 { get; set; } = string.Empty;
	public string FAXNR { get; set; } = string.Empty;
	public string INCHARGE { get; set; } = string.Empty;
	public string EMAILADDR { get; set; } = string.Empty;
	public string WEBADDR { get; set; } = string.Empty;
	public short? TEXTINC { get; set; }
	public short? CAPIBLOCK_CREATEDBY { get; set; }
	public DateTime? CAPIBLOCK_CREADEDDATE { get; set; }
	public short? CAPIBLOCK_CREATEDHOUR { get; set; }
	public short? CAPIBLOCK_CREATEDMIN { get; set; }
	public short? CAPIBLOCK_CREATEDSEC { get; set; }
	public short? CAPIBLOCK_MODIFIEDBY { get; set; }
	public DateTime? CAPIBLOCK_MODIFIEDDATE { get; set; }
	public short? CAPIBLOCK_MODIFIEDHOUR { get; set; }
	public short? CAPIBLOCK_MODIFIEDMIN { get; set; }
	public short? CAPIBLOCK_MODIFIEDSEC { get; set; }
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int? ORGLOGICREF { get; set; }
	public int? WFSTATUS { get; set; }
	public string CNTRYCODE { get; set; } = string.Empty;
	public string TOWN { get; set; } = string.Empty;
	public string DISTRICT { get; set; } = string.Empty;
	public string CORRPACC { get; set; } = string.Empty;
	public string VOEN { get; set; } = string.Empty;
	public string GUID { get; set; } = string.Empty;

	#endregion
}
