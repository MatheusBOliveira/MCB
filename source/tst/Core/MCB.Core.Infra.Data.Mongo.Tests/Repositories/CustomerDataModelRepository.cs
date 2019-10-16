using MCB.Core.Infra.Data.Mongo.Contexts;
using MCB.Core.Infra.Data.Mongo.Repositories;
using MCB.Core.Infra.Data.Mongo.Tests.DataModels;
using MCB.Core.Infra.Data.Mongo.Tests.Repositories.Interfaces;

namespace MCB.Core.Infra.Data.Mongo.Tests.Repositories
{
    public class CustomerDataModelRepository
        : RepositoryBase<CustomerDataModel>,
        ICustomerDataModelRepository
    {
        public CustomerDataModelRepository(MongoDbContext mongoDbContext)
            : base(mongoDbContext)
        {

        }
    }
}


