using Helix.EventBus.Base.Events;
using Helix.ProductionService.Domain.Dtos;

namespace Helix.ProductionService.Domain.Events;

public class WorkOrdersInsertedIntegrationEvent : IntegrationEvent
{
	public IList<WorkOrderDto> WorkOrders { get; private set; }

	public WorkOrdersInsertedIntegrationEvent(IList<WorkOrderDto> workOrders)
	{
		WorkOrders = workOrders;
	}
}
