using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Commands.Users
{
    public class LogoutSessionCommand
        : CommandBase
    {
        public string SessionToken { get; set; }
        public EmailValueObject Email { get; set; }
    }
}
