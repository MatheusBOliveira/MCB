using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Specification
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationSpec;

        public string Code
        {
            get;
            private set;
        }

        public Rule(ISpecification<TEntity> spec, string code)
        {
            _specificationSpec = spec;
            Code = code;
        }

        public async Task<bool> Validate(TEntity entity)
        {
            return await _specificationSpec.IsSatisfiedBy(entity);
        }
    }
}


