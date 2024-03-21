using Helix.EventBus.Base.Events;

namespace Helix.LBSService.PostConsumer.Events
{
	public class OutSourceWorkOrderChangeStatusInsertedIntegrationEvent : IntegrationEvent
	{
		public string FicheNo { get; set; } = string.Empty;
		public int Status { get; set; } = 0;
		public short DeleteFiche { get; set; } = 2;
	}
}