using Helix.EventBus.Base.Events;

namespace Helix.LBSService.PostConsumer.Events
{
	public class WorkOrderInsertActualQuantityIntegrationEvent : IntegrationEvent
	{
		public int WorkOrderReferenceId { get; private set; }
		public int ProductReferenceId { get; private set; }
		public double ActualQuantity { get; private set; }
		public int SubUnitsetReferenceId { get; private set; }
		public short CalculatedMethod { get; private set; }
		public bool IsIncludeSideProduct { get; private set; }
	}
}