using MCB.Admin.Domain.DomainModels;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Events.Users
{
    public class UserLoginSuccessfulEvent
        : EventBase
    {
        public ApplicationUserSession ApplicationUserSession { get; set; }
    }
}
