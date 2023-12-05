namespace Helix.Go.Entity;

public class LG_SERILOTN
{
	public int LOGICALREF { get; set; }
	public int ITEMREF { get; set; }
	public short SLTYPE { get; set; } = default;
	public string CODE { get; set; } = string.Empty;
	public string NAME { get; set; } = string.Empty;
	public short? STATE { get; set; }
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int? ORGLOGICREF { get; set; }
	public int? WFSTATUS { get; set; }
	public string ORGLOGOID { get; set; } = string.Empty;
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
	public int? VARIANTREF { get; set; }
	public string GROUPLOTNO { get; set; } = string.Empty;
}
