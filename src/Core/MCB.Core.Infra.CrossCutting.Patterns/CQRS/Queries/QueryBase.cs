using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Events;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries
{
    public abstract class QueryBase
        : MessageBase
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract Task<bool> IsValid();
    }
}


