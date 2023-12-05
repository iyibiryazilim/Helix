namespace Helix.Go.Entity;

public class LG_STOPTRANS
{
	#region Properties
	public int LOGICALREF { get; set; }
	public int? PRODORDREF { get; set; } = default;
	public int? DISPLINEREF { get; set; } = default;
	public int? OPREF { get; set; } = default;
	public int? WSREF { get; set; } = default;
	public int? CAUSEREF { get; set; } = default;
	public DateTime STOPDATE { get; set; } = default;
	public int? STOPTIME { get; set; } = default;
	public DateTime STARTDATE { get; set; } = default;
	public int? STARTTIME { get; set; } = default;
	public double? STOPDURATION { get; set; } = default;
	public short? AFFECTSCOST { get; set; } = default;
	public short? AFFECTSPLAN { get; set; } = default;
	public string TRANSEXP { get; set; } = string.Empty;
	public short? LINENR { get; set; } = default;
	public int? WSPARTREF { get; set; } = default;
	public short? ACTIVEPARTNUM { get; set; } = default;
	#endregion
}
