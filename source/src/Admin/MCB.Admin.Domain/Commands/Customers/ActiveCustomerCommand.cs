using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Commands.Customers
{
    public class ActiveCustomerCommand
        : CommandBase
    {
        public EmailValueObject Email { get; set; }
    }
}
