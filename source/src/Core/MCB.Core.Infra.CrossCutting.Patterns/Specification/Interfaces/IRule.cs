using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces
{
    public interface IRule<in TEntity>
    {
        string Code
        {
            get;
        }

        Task<bool> Validate(TEntity entity);
    }
}


