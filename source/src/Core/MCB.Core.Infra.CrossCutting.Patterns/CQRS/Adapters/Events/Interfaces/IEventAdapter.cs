using MCB.Core.Infra.CrossCutting.Patterns.Adapter.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Adapters.Events.Interfaces
{
    public interface IEventAdapter<TEvent>
        : IAdapter<TEvent, CommandBase>
        where TEvent : EventBase
    {
    }
}
