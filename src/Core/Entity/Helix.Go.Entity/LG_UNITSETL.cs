using System.Runtime.Serialization;

namespace Helix.Go.Entity;

public class LG_UNITSETL
{
	#region Properties

	public int LOGICALREF { get; set; }

	public string CODE { get; set; } = string.Empty;

	public string NAME { get; set; } = string.Empty;

	public int UNITSETREF { get; set; } = default;

	public short LINENR { get; set; } = default;

	public short MAINUNIT { get; set; } = default;

	public double CONVFACT1 { get; set; } = default;

	public double CONVFACT2 { get; set; } = default;
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
	public short DIVUNIT { get; set; } = default;
	public string MEASURECODE { get; set; } = string.Empty;
	public string GLOBALCODE { get; set; } = string.Empty;

	#endregion
}
