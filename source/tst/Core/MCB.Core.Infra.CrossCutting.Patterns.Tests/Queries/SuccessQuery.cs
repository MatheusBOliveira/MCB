using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Queries
{
    public class SuccessQuery
        : QueryBase
    {
        public string EmailAddress { get; set; }

        public SuccessQuery(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public async override Task<bool> IsValid()
        {
            return await Task.FromResult(true);
        }
    }
}


