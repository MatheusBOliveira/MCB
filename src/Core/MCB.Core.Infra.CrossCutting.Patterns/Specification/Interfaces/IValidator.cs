using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces
{
    public interface IValidator<in TEntity>
    {
        Task<ValidationResult> Validate(TEntity entity);
    }
}


