using Newtonsoft.Json;

namespace Helix.EventBus.Base.Events
{
    public class IntegrationEvent
    {
        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public DateTime CreatedOn { get; private set; }

       
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createdOn)
        {
            Id  = id;
            CreatedOn = createdOn;
        }
    }
}
