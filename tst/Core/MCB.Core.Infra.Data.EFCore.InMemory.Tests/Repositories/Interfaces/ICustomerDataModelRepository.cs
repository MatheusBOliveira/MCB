using MCB.Core.Infra.Data.EFCore.InMemory.Tests.DataModels;
using MCB.Core.Infra.Data.Repositories.Interfaces;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Tests.Repositories.Interfaces
{
    public interface ICustomerDataModelRepository
        : IAuditableRepository<CustomerDataModel>,
        IActivableRepository<CustomerDataModel>
    {
    }
}


