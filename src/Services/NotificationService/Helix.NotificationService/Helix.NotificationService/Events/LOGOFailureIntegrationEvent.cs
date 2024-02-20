using Helix.EventBus.Base.Events;

namespace Helix.NotificationService.Events
{
	public class LOGOFailureIntegrationEvent : IntegrationEvent
	{
		public int? FicheId { get; set; }
		public bool IsSucces { get; set; } = false;
		public string Message { get; set; } = string.Empty;
		public Guid? ApplicationOwner { get; set; }
		public object? Dto { get; set; }
		 
	}
}
