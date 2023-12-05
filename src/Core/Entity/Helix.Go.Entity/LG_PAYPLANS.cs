namespace Helix.Go.Entity;

public class LG_PAYPLANS
{
	#region Properties
	public int LOGICALREF { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string DEFINITION_ { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public double? EARLYINTEREST { get; set; }
	public double? LATEINTEREST { get; set; }
	public int? COUNTER { get; set; }
	public short? WRKDAYS { get; set; }
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
	public short? SITEID { get; set; }
	public int? ORGLOGICREF { get; set; }
	public short? RECSTATUS { get; set; }
	public int? WFSTATUS { get; set; }
	public string PPGROUPCODE { get; set; } = string.Empty;
	public int? PPGROUPREF { get; set; }
	public int? BANKACCREF { get; set; }
	public string DEFINITION2 { get; set; } = string.Empty;
	public string GLOBALCODE { get; set; } = string.Empty;
	#endregion
}
