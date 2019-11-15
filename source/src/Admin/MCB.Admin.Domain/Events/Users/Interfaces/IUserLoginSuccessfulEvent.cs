using MCB.Admin.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Admin.Domain.Events.Users.Interfaces
{
    public interface IUserLoginSuccessfulEvent
    {
        ApplicationUserSession ApplicationUserSession { get; set; }
    }
}
