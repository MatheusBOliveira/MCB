using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Bus.InMemory.Tests.Queries
{
    public class FailQuery
        : QueryBase
    {
        public string EmailAddress { get; set; }

        public FailQuery(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public async override Task<bool> IsValid()
        {
            return await Task.FromResult(true);
        }
    }
}


