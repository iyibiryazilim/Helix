namespace Helix.Go.Entity;

public class LG_LOCATION
{
	public int LOGICALREF { get; set; }
	public short? INVENNR { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string NAME { get; set; } = string.Empty;
	public short? WIDTH { get; set; }
	public short? LENGTH { get; set; }
	public short? HEIGHT { get; set; }
	public int WIDTHREF { get; set; }
	public int LENGTHREF { get; set; }
	public int HEIGHTREF { get; set; }
	public double? MINLEVEL { get; set; }
	public double? MAXLEVEL { get; set; }
	public short? SHELFTYPE { get; set; }
	public short? CONTENTTYPE { get; set; }
	public short? PRIORITY { get; set; }
	public int USETREF { get; set; }
	public int UOMREF { get; set; }
	public short? ISEUROPALETTE { get; set; }
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int ORGLOGICREF { get; set; }
	public int WFSTATUS { get; set; }
}
