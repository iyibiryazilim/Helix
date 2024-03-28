using Helix.EventBus.Base.Events;

namespace Helix.LBSService.Tiger.DTOs
{
	public class WorkOrdersDto : IntegrationEvent
	{
		public IList<WorkOrderDto> WorkOrders { get; set; }

		public WorkOrdersDto()
		{
			WorkOrders = new List<WorkOrderDto>();
		}
	}

	public class WorkOrderDto : IntegrationEvent
	{
		public int WorkOrderReferenceId { get; set; }

		public int ProductReferenceId { get; set; }

		public double ActualQuantity { get; set; }

		public int SubUnitsetReferenceId { get; set; }

		public short CalculatedMethod { get; set; }

		public bool IsIncludeSideProduct { get; set; }
	}
}