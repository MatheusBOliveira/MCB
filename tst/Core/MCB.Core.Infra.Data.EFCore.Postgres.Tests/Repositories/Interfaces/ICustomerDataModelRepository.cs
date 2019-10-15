using MCB.Core.Infra.Data.EFCore.Postgres.Tests.DataModels;
using MCB.Core.Infra.Data.Repositories.Interfaces;

namespace MCB.Core.Infra.Data.EFCore.Postgres.Tests.Repositories.Interfaces
{
    public interface ICustomerDataModelRepository
        : IAuditableRepository<CustomerDataModel>,
        IActivableRepository<CustomerDataModel>
    {
    }
}


