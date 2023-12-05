namespace Helix.Go.Entity;

public class LG_ROUTING
{
	#region Properties 

	public int LOGICALREF { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string NAME { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public short APPROVED { get; set; }
	public short ACTIVE { get; set; }
	public short CAPIBLOCK_CREATEDBY { get; set; }
	public DateTime CAPIBLOCK_CREADEDDATE { get; set; }
	public short CAPIBLOCK_CREATEDHOUR { get; set; }
	public short CAPIBLOCK_CREATEDMIN { get; set; }
	public short CAPIBLOCK_CREATEDSEC { get; set; }
	public short CAPIBLOCK_MODIFIEDBY { get; set; }
	public DateTime CAPIBLOCK_MODIFIEDDATE { get; set; }
	public short CAPIBLOCK_MODIFIEDHOUR { get; set; }
	public short CAPIBLOCK_MODIFIEDMIN { get; set; }
	public short CAPIBLOCK_MODIFIEDSEC { get; set; }
	public short SITEID { get; set; }
	public short RECSTATUS { get; set; }
	public int ORGLOGICREF { get; set; }
	public short TEXTINC { get; set; }
	public int WFSTATUS { get; set; }
	public short PRINTCNT { get; set; }
	public string GUID { get; set; } = string.Empty;
	public short CARDTYPE { get; set; }
	public DateTime PRINTDATE { get; set; }
	#endregion
}
