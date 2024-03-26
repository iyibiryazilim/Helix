using Helix.EventBus.Base.Events;

namespace Helix.ProductionService.Domain.Events;

public class WorkOrderChangeStatusInsertedIntegrationEvent : IntegrationEvent
{
	public string FicheNo { get; private set; }
	public int Status { get; private set; }
	public short DeleteFiche { get; private set; }

	public WorkOrderChangeStatusInsertedIntegrationEvent(Guid eventId, string ficheNo, int status, short deleteFiche)
	{
		Id = eventId;
		FicheNo = ficheNo;
		Status = status;
		DeleteFiche = deleteFiche;
	}
}