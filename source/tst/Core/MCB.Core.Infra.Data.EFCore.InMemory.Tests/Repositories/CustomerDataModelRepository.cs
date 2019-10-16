using MCB.Core.Infra.Data.EFCore.Contexts.Interfaces;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.DataModels;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.Repositories.Interfaces;
using MCB.Core.Infra.Data.EFCore.Repositories;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Tests.Repositories
{
    public class CustomerDataModelRepository
        : RepositoryBase<CustomerDataModel>,
        ICustomerDataModelRepository
    {
        public CustomerDataModelRepository(IDbContext context) 
            : base(context)
        {

        }
    }
}


