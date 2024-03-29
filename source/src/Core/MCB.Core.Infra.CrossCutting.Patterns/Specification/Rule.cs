using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System.Globalization;
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
        public string DefaultDescription
        {
            get;
            private set;
        }

        public Rule(ISpecification<TEntity> spec, string code, string defaultDescription)
        {
            _specificationSpec = spec;
            Code = code;
            DefaultDescription = defaultDescription;
        }

        public async Task<bool> Validate(TEntity entity, CultureInfo culture)
        {
            return await _specificationSpec.IsSatisfiedBy(entity, culture);
        }
    }
}


