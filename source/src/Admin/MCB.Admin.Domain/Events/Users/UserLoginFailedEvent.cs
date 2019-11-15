using MCB.Admin.Domain.DomainModels;
using MCB.Admin.Domain.Events.Users.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Events.Users
{
    public class UserLoginFailedEvent
        : EventBase,
        IUserLoginFailedEvent
    {
        public Application Application { get; set; }
        public User User { get; set; }
    }
}
