using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.CrossCutting.Patterns.CQRS.Queries.Interfaces;
using System.Threading.Tasks;

namespace MCB.Admin.Domain.Queries.Customers.Interfaces
{
    public interface ICheckIfEmailExistsInRepositoryQuery
        : IQuery
    {
        EmailValueObject Email { get; set; }
    }
}