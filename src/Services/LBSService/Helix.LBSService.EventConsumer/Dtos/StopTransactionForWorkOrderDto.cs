namespace Helix.LBSService.EventConsumer.Dtos
{
	public class StopTransactionForWorkOrderDto
	{
		public int WorkOrderReferenceId { get; set; }
		public int StopCauseReferenceId { get; set; }
		public DateTime StopDate { get; set; } = DateTime.Now;
		public TimeSpan StopTime { get; set; } = DateTime.Now.TimeOfDay;
	}
}
