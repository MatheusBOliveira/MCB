using MCB.Core.Infra.Data.Mongo.Contexts;
using MCB.Core.Infra.Data.Mongo.Tests.DataModels;
using MCB.Core.Infra.Data.Mongo.Tests.Mappings;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;

namespace MCB.Core.Infra.Data.Mongo.Tests.Contexts
{
    public class TestContext
        : MongoDbContext
    {
        private readonly IConfiguration _config;

        public TestContext(IConfiguration config)
        {
            _config = config;
        }

        protected override string GetConnectionString()
        {
            var config = _config.GetConnectionString("MongoDBConnection");

            return config;
        }
        protected override string GetDatabaseName()
        {
            var config = _config["Database:MongoDB:DatabaseName"];

            return config;
        }

        protected override void ApplyMappings()
        {
            new CustomerDataModelMap(new BsonClassMap<CustomerDataModel>());
            new AppointmentDataModelMap(new BsonClassMap<AppointmentDataModel>());
        }
    }
}


