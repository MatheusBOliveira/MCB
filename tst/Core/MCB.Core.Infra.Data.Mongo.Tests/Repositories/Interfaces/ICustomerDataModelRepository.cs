using MCB.Core.Infra.Data.Mongo.Tests.DataModels;
using MCB.Core.Infra.Data.Repositories.Interfaces;

namespace MCB.Core.Infra.Data.Mongo.Tests.Repositories.Interfaces
{
    public interface ICustomerDataModelRepository
        : IAuditableRepository<CustomerDataModel>,
        IActivableRepository<CustomerDataModel>
    {

    }
}


