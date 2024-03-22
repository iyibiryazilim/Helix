using Helix.EventBus.Base.Events;

namespace Helix.LBSService.Base.Events
{
	public class SYSMessageIntegrationEvent : IntegrationEvent
	{
		public int? FicheId { get; set; }
		public bool IsSucces { get; set; }
		public string Message { get; set; } = string.Empty;
		public Guid? ApplicationOwner { get; set; }
		public object? Dto { get; set; }

		public SYSMessageIntegrationEvent(int? ficheId, bool isSucces, string message, Guid? applicationOwner, object dto)
		{
			FicheId = ficheId;
			Message = message;
			IsSucces = isSucces;
			ApplicationOwner = applicationOwner;
			Dto = dto;
		}
	}
}