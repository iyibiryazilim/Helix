using System.Runtime.Serialization;

namespace Helix.Go.Entity;

public class L_COUNTRY
{
	#region Properties

	public int LOGICALREF { get; set; }

	public string? CODE { get; set; }

	public string? NAME { get; set; }

	public int? COUNTRYNR { get; set; }
	#endregion
}
