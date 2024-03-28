namespace Helix.LBSService.Tiger.Models
{
	public class LG_Demand
	{
		public LG_Demand()
		{
			TRANSACTION = new List<LG_DemandLine>();
		}

		public string PROJECT_CODE { get; set; } = string.Empty;
		public System.DateTime DATE { get; set; } = DateTime.Now;
		public System.DateTime DATE_CREATED { get; set; } = DateTime.Now;
		public string DO_CODE { get; set; } = string.Empty;
		public string AUXIL_CODE { get; set; } = string.Empty;
		public short SOURCE_INDEX { get; set; } = default;
		public IList<LG_DemandLine> TRANSACTION { get; set; }
	}
}