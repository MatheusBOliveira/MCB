using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Commands;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Commands
{
    public class FailCommand
        : CommandBase
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public FailCommand(
            string name,
            string emailAddress)
        {
            Name = name;
            EmailAddress = emailAddress;
        }

        public async override Task<bool> IsValid()
        {
            return await Task.FromResult(true);
        }
    }
}


