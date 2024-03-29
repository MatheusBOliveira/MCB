using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Commands
{
    public class SuccessCommand
        : CommandBase
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public SuccessCommand(
            string name,
            string emailAddress)
        {
            Name = name;
            EmailAddress = emailAddress;
        }
    }
}


