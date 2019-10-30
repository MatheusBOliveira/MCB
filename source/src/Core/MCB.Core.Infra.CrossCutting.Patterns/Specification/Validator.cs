using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Specification
{
    public abstract class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> _validations = new Dictionary<string, IRule<TEntity>>();

        public virtual async Task<ValidationResult> Validate(TEntity entity)
        {
            var validationResult = new ValidationResult();
            foreach (var key in _validations.Keys)
            {
                var rule = _validations[key];
                if (await rule.Validate(entity) == false)
                {
                    validationResult.Add(new ValidationError(rule.Code, rule.DefaultDescription));
                }
            }
            return await Task.FromResult(validationResult);
        }

        protected virtual void AddSpecification(ISpecification<TEntity> specification)
        {
            var rule = new Rule<TEntity>(specification, specification.ErrorCode, specification.ErrorDefaultDescription);

            Add(specification.ErrorCode, rule);
        }

        protected virtual void Add(string name, IRule<TEntity> rule)
        {
            _validations.Add(name, rule);
        }

        protected virtual void Remove(string name)
        {
            _validations.Remove(name);
        }

        protected IRule<TEntity> GetRule(string name)
        {
            _validations.TryGetValue(name, out var value);
            return value;
        }
    }
}


