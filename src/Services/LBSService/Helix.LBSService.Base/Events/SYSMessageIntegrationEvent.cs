using Helix.EventBus.Base.Events;

namespace Helix.LBSService.Base.Events
{
	public class SYSMessageIntegrationEvent : IntegrationEvent
	{
		public object? Content { get; set; }

		public SYSMessageIntegrationEvent(Guid requestId, object dto)
		{
			Owner = requestId;
			Content = dto;
		}
	}
}