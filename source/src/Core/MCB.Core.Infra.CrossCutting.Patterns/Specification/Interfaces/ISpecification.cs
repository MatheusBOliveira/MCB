using System.Globalization;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces
{
    public interface ISpecification<in T>
    {
        string ErrorCode { get; }
        string ErrorDefaultDescription { get; }

        Task<bool> IsSatisfiedBy(T entity, CultureInfo cultureInfo);
    }
}


