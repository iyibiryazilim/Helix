using Helix.EventBus.Base.Events;

namespace Helix.NotificationService.Events
{
	public class LOGOSuccessIntegrationEvent : IntegrationEvent
	{
		public int? FicheId { get; set; }
		public bool IsSucces { get; set; } = true;
		public string Message { get; set; } = string.Empty;
		public Guid? ApplicationOwner { get; set; }
		public object? Dto { get; set; } 
	}
}
