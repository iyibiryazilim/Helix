namespace Helix.LBSService.Tiger.DTOs
{
	public class WorkOrderChangeStatusDto
	{
		public string FicheNo { get; set; } = string.Empty;
		public int Status { get; set; } = 0;
		public short DeleteFiche { get; set; } = 2;
 		public short ProductionType { get; set; } = 1;
		public bool OpenTransaction { get; set; } = true;
    }
}
 
