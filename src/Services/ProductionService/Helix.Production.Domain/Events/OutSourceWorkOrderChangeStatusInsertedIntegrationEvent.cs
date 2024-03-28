using Helix.EventBus.Base.Events;

namespace Helix.ProductionService.Domain.Events
{
	public class OutSourceWorkOrderChangeStatusInsertedIntegrationEvent : IntegrationEvent
	{
		public string FicheNo { get; private set; }
		public int Status { get; private set; }
		public short DeleteFiche { get; private set; }

		public OutSourceWorkOrderChangeStatusInsertedIntegrationEvent(Guid eventId, string ficheNo, int status, short deleteFiche)
		{
			Owner = eventId;
			FicheNo = ficheNo;
			Status = status;
			DeleteFiche = deleteFiche;
		}
	}
}