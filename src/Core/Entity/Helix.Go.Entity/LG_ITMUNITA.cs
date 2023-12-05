namespace Helix.Go.Entity;

public class LG_ITMUNITA
{
	#region Properties
	public int LOGICALREF { get; set; } = default;
	public int ITEMREF { get; set; } = default;
	public short LINENR { get; set; } = default;
	public int UNITLINEREF { get; set; } = default;
	public string BARCODE { get; set; } = string.Empty;
	public short MTRLCLAS { get; set; } = default;
	public short PURCHCLAS { get; set; } = default;
	public short SALESCLAS { get; set; } = default;
	public short MTRLPRIORITY { get; set; } = default;
	public short PURCHPRIORTY { get; set; } = default;
	public short SALESPRIORITY { get; set; } = default;
	public double WIDTH { get; set; } = default;
	public double LENGTH { get; set; } = default;
	public double HEIGHT { get; set; } = default;
	public double AREA { get; set; } = default;
	public double VOLUME_ { get; set; } = default;
	public double WEIGHT { get; set; } = default;
	public int WIDTHREF { get; set; } = default;
	public int LENGTHREF { get; set; } = default;
	public int HEIGHTREF { get; set; } = default;
	public int AREAREF { get; set; } = default;
	public int VOLUMEREF { get; set; } = default;
	public int WEIGHTREF { get; set; } = default;
	public double GROSSVOLUME { get; set; } = default;
	public double GROSSWEIGHT { get; set; } = default;
	public int GROSSVOLREF { get; set; } = default;
	public int GROSSWGHTREF { get; set; } = default;
	public double CONVFACT1 { get; set; } = default;
	public double CONVFACT2 { get; set; } = default;
	public int EXTACCESSFLAGS { get; set; } = default;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public string BARCODE2 { get; set; } = string.Empty;
	public string BARCODE3 { get; set; } = string.Empty;
	public string WBARCODE { get; set; } = string.Empty;
	public short WBARCODESHIFT { get; set; } = default;
	public int VARIANTREF { get; set; } = default;
	public string GLOBALID { get; set; } = string.Empty;
	#endregion
}
