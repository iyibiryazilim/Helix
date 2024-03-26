namespace Helix.LBSService.Tiger.Models
{
	public class LG_DemandLine
	{
		public double AMOUNT { get; set; } = default;
		public DateTime PROCURE_DATE { get; set; } = DateTime.Now;
		public DateTime FICHE_DATE { get; set; } = DateTime.Now;
		public string ARP_CODE { get; set; } = string.Empty;
		public string ITEM_CODE { get; set; } = string.Empty;
		public string UNIT_CODE { get; set; } = string.Empty;
		public double PRICE { get; set; } = default;
		public string VARIANTCODE { get; set; } = string.Empty;
		public string PROJECT_CODE { get; set; } = string.Empty;
	}
}