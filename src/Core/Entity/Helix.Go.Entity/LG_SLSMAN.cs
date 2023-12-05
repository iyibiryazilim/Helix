namespace Helix.Go.Entity;

public class LG_SLSMAN
{
	#region Properties
	public int LOGICALREF { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string DEFINITION_ { get; set; } = string.Empty;
	public short? CARDTYPE { get; set; }
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public string POSITION_ { get; set; } = string.Empty;
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
	public short? ACTIVE { get; set; }
	public int? SITEID { get; set; }
	public int? ORGLOGICREF { get; set; }
	public short? USERID { get; set; }
	public short? DEPTID { get; set; }
	public short? DIVISID { get; set; }
	public short? FIRMNR { get; set; }
	public short? RECSTATUS { get; set; }
	public short? TYP { get; set; }
	public string TELNUMBER { get; set; } = string.Empty;
	#endregion
}
