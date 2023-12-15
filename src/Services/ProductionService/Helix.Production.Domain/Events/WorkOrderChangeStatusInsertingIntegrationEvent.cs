using Helix.EventBus.Base.Events;

namespace Helix.ProductionService.Domain.Events;

public class WorkOrderChangeStatusInsertingIntegrationEvent : IntegrationEvent
{
	public string FicheNo { get; private set; }
	public int Status { get; private set; }
	public short DeleteFiche { get; private set; }

	public WorkOrderChangeStatusInsertingIntegrationEvent(string ficheNo, int status, short deleteFiche)
	{
		FicheNo = ficheNo;
		Status = status;
		DeleteFiche = deleteFiche;
	}
}
