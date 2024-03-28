using Helix.EventBus.Base.Events;

namespace Helix.LBSNotification.Events
{
    public class SysMessageIntegrationEvent : IntegrationEvent
    {
        public Guid Owner { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
