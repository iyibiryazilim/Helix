using Helix.EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.EventBus.Base.Abstractions;

public interface IIntegrationEventHandler<TIntegrationEvent> : IntegrationEventHandler where TIntegrationEvent : IntegrationEvent
{
	public Task Handle(TIntegrationEvent @event);
}

public interface IntegrationEventHandler
{
}