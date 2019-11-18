using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Adapters.Events.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Adapters.Events
{
    public abstract class EventAdapterBase<TEvent>
        : IEventAdapter<TEvent>
        where TEvent : IEvent
    {

        public virtual TEvent Adapt(TEvent target, CommandBase source)
        {
            target.ValidationResult.Add(source.ValidationResult);

            return target;
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
