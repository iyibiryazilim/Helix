namespace Helix.Go.Entity;

public class LG_UNITBARCODE
{
	#region Properties
	public int LOGICALREF { get; set; } = default;
	public int ITMUNITAREF { get; set; } = default;
	public int ITEMREF { get; set; } = default;
	public int VARIANTREF { get; set; } = default;
	public int UNITLINEREF { get; set; } = default;
	public short LINENR { get; set; } = default;
	public string BARCODE { get; set; } = string.Empty;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public short TYP { get; set; } = default;
	public short WBARCODESHIFT { get; set; } = default;
	public string GLOBALID { get; set; } = string.Empty;
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
	#endregion
}
