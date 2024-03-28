using Helix.EventBus.Base.Events;

namespace Helix.LBSService.Tiger.DTOs
{
	public class WorkOrderChangeStatusDto : IntegrationEvent
	{
		public string FicheNo { get; set; } = string.Empty;
		public int Status { get; set; } = 0;
		public short DeleteFiche { get; set; } = 2;
	}
}