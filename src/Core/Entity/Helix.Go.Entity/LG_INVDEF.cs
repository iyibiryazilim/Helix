namespace Helix.Go.Entity;

public class LG_INVDEF
{
	#region Properties
	public int LOGICALREF { get; set; }
	public short? INVENNO { get; set; }
	public int? ITEMREF { get; set; }
	public double? MINLEVEL { get; set; }
	public double? MAXLEVEL { get; set; }
	public double? SAFELEVEL { get; set; }
	public int? LOCATIONREF { get; set; }
	public DateTime? PERCLOSEDATE { get; set; }
	public short? ABCCODE { get; set; }
	public short? MINLEVELCTRL { get; set; }
	public short? MAXLEVELCTRL { get; set; }
	public short? SAFELEVELCTRL { get; set; }
	public short? NEGLEVELCTRL { get; set; }
	public short? IOCTRL { get; set; }
	public int? VARIANTREF { get; set; }
	public short? OUTCTRL { get; set; }
	#endregion
}
