using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands
{
    public class RegisterNewCustomerCommand
        : CommandBase
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}


