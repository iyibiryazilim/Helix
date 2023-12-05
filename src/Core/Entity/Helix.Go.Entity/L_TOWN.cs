using System.Runtime.Serialization;

namespace Helix.Go.Entity;

public class L_TOWN
{
	#region Properties

	public int LOGICALREF { get; set; }

	public string? NAME { get; set; }

	public string? CODE { get; set; }

	public int? CTYREF { get; set; }

	public int? CNTRNR { get; set; }

	#endregion
}
