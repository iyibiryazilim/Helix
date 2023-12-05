namespace Helix.Go.Entity;

public class LG_MNTDEMANDLINE
{
	public int LOGICALREF { get; set; } = default;
	public int DEMANDFICHEREF { get; set; } = default;
	public int ITEMREF { get; set; } = default;
	public int FAREGREF { get; set; } = default;
	public int WSREF { get; set; } = default;
	public short MAINTTYPE { get; set; } = default;
	public short LINETYPE { get; set; } = default;
	public short BRANCH { get; set; } = default;
	public short DEPARTMENT { get; set; } = default;
	public short FACTORYNR { get; set; } = default;
	public string SPECODE { get; set; } = string.Empty;
	public string LINEEXP { get; set; } = string.Empty;
	public short STATUS { get; set; } = default;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public int WFSTATUS { get; set; } = default;
	public string CYPHCODE { get; set; } = string.Empty;
	public short LINENO_ { get; set; } = default;
	public int PERREF { get; set; } = default;
	public DateTime FICHEDATE { get; set; } = default;
	public int PROJECTREF { get; set; } = default;
	public string GUID { get; set; } = string.Empty;
}
