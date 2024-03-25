using Helix.EventBus.Base.Events;

namespace Helix.LBSService.Base.Events
{
	public class LOGOFailureIntegrationEvent : IntegrationEvent
	{
		public int? FicheId { get; set; }
		public bool IsSucces { get; set; } = false;
		public string Message { get; set; } = string.Empty;
		public Guid? ApplicationOwner { get; set; }
		public object? Dto { get; set; }

		public LOGOFailureIntegrationEvent(int? ficheId, string message, Guid? applicationOwner, object dto)
		{
			FicheId = ficheId;
			Message = message;
			IsSucces = false;
			ApplicationOwner = applicationOwner;
			Dto = dto;
		}
	}
}