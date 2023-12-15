using Helix.EventBus.Base.Events;
using Helix.ProductionService.Domain.Dtos;

namespace Helix.ProductionService.Domain.Events;

public class WorkOrdersInsertingIntegrationEvent : IntegrationEvent
{
	public IList<WorkOrderDto> WorkOrders { get; private set; }

	public WorkOrdersInsertingIntegrationEvent(IList<WorkOrderDto> workOrders)
	{
		WorkOrders = workOrders;
	}
}
