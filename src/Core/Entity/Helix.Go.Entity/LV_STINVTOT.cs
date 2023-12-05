namespace Helix.Go.Entity;

public class LV_STINVTOT
{
	#region Properties
	public int LOGICALREF { get; set; }
	public int? STOCKREF { get; set; }
	public int? INVENNO { get; set; }
	public DateTime? DATE_ { get; set; }
	public double? ONHAND { get; set; }
	public double? ACTPORDER { get; set; }
	public double? RECEIVED { get; set; }
	public double? ACTWASTE { get; set; }
	public double? PURAMNT { get; set; }
	public double? PURCASH { get; set; }
	public double? PURCURR { get; set; }
	public DateTime? LASTTRDATE { get; set; } = default;
	public double? ACTWHOUSEIN { get; set; }
	public double? ACTWHOUSEOUT { get; set; }
	public int? VARIANTREF { get; set; }
	public int? INVENCOSTGRP { get; set; }

	#endregion
}
