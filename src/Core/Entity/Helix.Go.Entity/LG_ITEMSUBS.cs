namespace Helix.Go.Entity;

public class LG_ITEMSUBS
{
	#region Properties
	public int LOGICALREF { get; set; }
	public int? MAINITEMREF { get; set; }
	public int? SUBITEMREF { get; set; }
	public short? LINENO_ { get; set; }
	public short? PRIORITY { get; set; }
	public double? CONVFACT1 { get; set; }
	public double? CONVFACT2 { get; set; }
	public double? MAXQUANTITY { get; set; }
	public double? MINQUANTITY { get; set; }
	public DateTime? BEGDATE { get; set; }
	public DateTime? ENDDATE { get; set; }
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int? ORGLOGICREF { get; set; }
	public int? MAINVRNTREF { get; set; }
	public int? SUBVRNTREF { get; set; }
	public short? SOURCEINDEX { get; set; }
	#endregion
}
