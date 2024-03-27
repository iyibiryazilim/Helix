using Helix.EventBus.Base.Events;

namespace Helix.LBSService.PostConsumer.Events
{
    public class WorkOrderInsertActualQuantityIntegrationEvent : IntegrationEvent
    {
        public int WorkOrderReferenceId { get; set; }
        public int ProductReferenceId { get; set; }
        public double ActualQuantity { get; set; }
        public int SubUnitsetReferenceId { get; set; }
        public short CalculatedMethod { get; set; }
        public bool IsIncludeSideProduct { get; set; }
    }
}