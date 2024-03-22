namespace Helix.LBSService.Tiger.Models
{
	public class LG_Variant
	{
		public LG_Variant()
		{
			VRNT_ASSIGNS = new List<LG_VRNTASSIGN>();
		}

		public int INTERNAL_REFERENCE { get; set; }
		public short CARDTYPE { get; set; }
		public string CODE { get; set; } = string.Empty;
		public string NAME { get; set; } = string.Empty;
		public string CYPHCODE { get; set; } = string.Empty;
		public string UNITSETCODE { get; set; } = string.Empty;
		public int DATA_REFERENCE { get; set; }
		public int CAPIBLOCK_CREATEDBY { get; set; }
		public DateTime CAPIBLOCK_CREADEDDATE { get; set; } = DateTime.Now;
		public int CAPIBLOCK_CREATEDHOUR { get; set; } = DateTime.Now.Hour;
		public int CAPIBLOCK_CREATEDMIN { get; set; } = DateTime.Now.Minute;
		public int CAPIBLOCK_CREATEDSEC { get; set; } = DateTime.Now.Second;
		public string ICODE { get; set; } = string.Empty;
		public string IDEF { get; set; } = string.Empty;

		public IList<LG_VRNTASSIGN> VRNT_ASSIGNS { get; set; }
	}
}