using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Commands.Customers
{
    public class RegisterNewCustomerCommand
        : CommandBase
    {
        public string Name { get; set; }
        public EmailValueObject Email { get; set; }
        public PhoneNumberValueObject PhoneNumber { get; set; }
        public PasswordValueObject Password { get; set; }
        public string ApplicationName { get; set; }
    }
}
