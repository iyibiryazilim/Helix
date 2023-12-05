using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs
{
	public class StopTransactionForWorkOrderInsertDto : BaseDto
	{
        public int WorkOrderReferenceId { get; set; } 
        public int StopCauseReferenceId { get; set; }
        public DateTime StopDate { get; set; } = DateTime.Now; 
		public TimeSpan StopTime { get; set; } = DateTime.Now.TimeOfDay;

	}
}
