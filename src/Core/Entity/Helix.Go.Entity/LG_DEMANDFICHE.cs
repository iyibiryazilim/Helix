namespace Helix.Go.Entity;

public class LG_DEMANDFICHE
{
	#region Properties
	public int LOGICALREF { get; set; }
	public string FICHENO { get; set; } = string.Empty;
	public DateTime DATE_ { get; set; } = default;
	public int TIME_ { get; set; } = default;
	public string DOCODE { get; set; } = string.Empty;
	public short STATUS { get; set; } = default;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public short SOURCEINDEX { get; set; } = default;
	public short BRANCH { get; set; } = default;
	public short DEPARTMENT { get; set; } = default;
	public short FACTORYNR { get; set; } = default;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public int WFSTATUS { get; set; } = default;
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
	public short DEMANDTYPE { get; set; } = default;
	public int DEMANDREF { get; set; } = default;
	public short PRINTCNT { get; set; } = default;
	public short TEXTINC { get; set; } = default;
	public short USERNO { get; set; } = default;
	public int WFLOWCRDREF { get; set; } = default;
	public int PROJECTREF { get; set; } = default;
	public int PERREF { get; set; } = default;
	public string GUID { get; set; } = string.Empty;
	#endregion
}
