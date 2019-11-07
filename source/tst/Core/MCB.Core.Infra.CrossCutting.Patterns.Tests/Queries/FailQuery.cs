using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Tests.Queries
{
    public class FailQuery
        : QueryBase
    {
        public string EmailAddress { get; set; }

        public FailQuery(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public override void Validate()
        {
            ValidationResult = new Specification.ValidationResult();
        }
    }
}


