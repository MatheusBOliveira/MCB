using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Events
{
    public class SuccessEvent
        : EventBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public List<string> Roles { get; set; }

        public SuccessEvent()
        {
            Roles = new List<string>();
        }
    }
}


