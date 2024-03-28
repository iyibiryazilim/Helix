using Helix.EventBus.Base.Events;

namespace Helix.LBSNotification.Events
{
    public class SYSMessageIntegrationEvent : IntegrationEvent
    {
        public Guid Owner { get; set; }
        public object Content { get; set; }

    }
}
