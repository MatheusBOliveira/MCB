using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Commands.Users
{
    public class LogoutAllSessionsCommand
        : CommandBase
    {
        public EmailValueObject Email { get; set; }
    }
}
