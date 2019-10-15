using MongoDB.Driver;
using System;

namespace MCB.Core.Infra.Data.Mongo.Contexts
{
    public abstract class MongoDbContext
        : IDisposable
    {
        public MongoClient MongoClient { get; set; }
        public IMongoDatabase MongoDatabase { get; set; }


        public void CreateConnection()
        {
            ApplyMappings();

            MongoClient = new MongoClient(GetConnectionString());
            MongoDatabase = MongoClient.GetDatabase(GetDatabaseName());
        }

        protected abstract void ApplyMappings();

        protected abstract string GetConnectionString();
        protected abstract string GetDatabaseName();

        public void Dispose()
        {
            MongoDatabase = null;
            MongoClient = null;
        }
    }
}


