using Helix.EventBus.Base.Events;

namespace Helix.ProductionService.Domain.Events
{
	public class OutSourceWorkOrderChangeStatusInsertedIntegrationEvent : IntegrationEvent
	{
		public string FicheNo { get; private set; }
		public int Status { get; private set; }
		public short DeleteFiche { get; private set; }

		public OutSourceWorkOrderChangeStatusInsertedIntegrationEvent(string ficheNo, int status, short deleteFiche)
		{
			FicheNo = ficheNo;
			Status = status;
			DeleteFiche = deleteFiche;
		}
	}
}