using Helix.EventBus.Base.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.TestEvents.Events;

namespace TestProject1.TestEvents.EventHandlers
{
    public class OrderCreatedIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedIntegrationEvent>
    {
        public Task Handle(OrderCreatedIntegrationEvent @event)
        {
            Console.WriteLine($"Handle method worked with {@event.Id}");
            return Task.CompletedTask;
        }
    }
}
