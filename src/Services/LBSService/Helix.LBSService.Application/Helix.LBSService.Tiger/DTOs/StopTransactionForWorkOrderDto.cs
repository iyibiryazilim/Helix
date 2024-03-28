using Helix.EventBus.Base.Events;

namespace Helix.LBSService.Tiger.DTOs
{
	public class StopTransactionForWorkOrderDto : IntegrationEvent
	{
		public int WorkOrderReferenceId { get; set; }
		public int StopCauseReferenceId { get; set; }
		public DateTime StopDate { get; set; } = DateTime.Now;
	}
}