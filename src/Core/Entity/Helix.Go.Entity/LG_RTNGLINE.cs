namespace Helix.Go.Entity;

public class LG_RTNGLINE
{
	public int LOGICALREF { get; set; }
	public int ROUTINGREF { get; set; } = default;
	public short LINENO_ { get; set; } = default;
	public int OPERATIONREF { get; set; } = default;
	public string SPECODE { get; set; } = string.Empty;
	public short COSTRELATED { get; set; } = default;
	public short PLANRELATED { get; set; } = default;
	public int OUTITEMREF { get; set; } = default;
	public string LINEEXP { get; set; } = string.Empty;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public int WFSTATUS { get; set; } = default;
}
