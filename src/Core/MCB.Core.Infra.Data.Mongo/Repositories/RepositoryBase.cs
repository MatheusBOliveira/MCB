using MCB.Core.Infra.Data.DataModels.Interfaces;
using MCB.Core.Infra.Data.Mongo.Contexts;
using MCB.Core.Infra.Data.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MCB.Core.Infra.Data.Mongo.DataModels.Interfaces;

namespace MCB.Core.Infra.Data.Mongo.Repositories
{
    public abstract class RepositoryBase<TDataModel>
        : IRepository<TDataModel>,
        IActivableRepository<TDataModel>,
        IAuditableRepository<TDataModel>
        where TDataModel : IMongoDataModel
    {
        private readonly MongoDbContext _mongoDbContext;
        private readonly IMongoCollection<TDataModel> _mongoCollection;

        public MongoDbContext MongoDbContext
        {
            get
            {
                return _mongoDbContext;
            }
        }
        public IMongoCollection<TDataModel> MongoCollection
        {
            get
            {
                return _mongoCollection;
            }
        }

        public RepositoryBase(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            _mongoCollection = _mongoDbContext.MongoDatabase
                .GetCollection<TDataModel>(
                    typeof(TDataModel).GetAttribute<BsonDiscriminatorAttribute>()
                    .Discriminator
                );
        }

        public async Task<TDataModel> AddAsync(TDataModel dataModel)
        {
            dataModel.Id = Guid.Parse(dataModel.DataModelId);

            if (dataModel is IAuditableDataModel auditableDataModel)
                if (auditableDataModel.RegistryVersion == null)
                    auditableDataModel.RegistryVersion =
                        BitConverter.GetBytes(DateTime.UtcNow.Ticks);

            await MongoCollection.InsertOneAsync(dataModel);

            return dataModel;
        }
        public async Task<TDataModel> UpdateAsync(TDataModel dataModel)
        {
            dataModel.Id = Guid.Parse(dataModel.DataModelId);

            if (dataModel is IAuditableDataModel auditableDataModel)
                if (auditableDataModel.RegistryVersion == null)
                    auditableDataModel.RegistryVersion =
                        BitConverter.GetBytes(DateTime.UtcNow.Ticks);

            var updateDef = Builders<TDataModel>.Update.Combine(
                dataModel.GetPropertyChangedCollection().Select(q =>
                    Builders<TDataModel>.Update.Set(
                        q,
                        dataModel.GetType()
                            .GetProperty(q)
                            .GetValue(dataModel))
                )
            );

            var filter = Builders<TDataModel>.Filter.Eq(x => x.DataModelId, dataModel.DataModelId);

            var update = await MongoCollection.UpdateOneAsync(
                filter,
                updateDef);

            return dataModel;
        }
        public async Task RemoveAsync(Guid id)
        {
            if (!typeof(IMongoDataModel).IsAssignableFrom(typeof(TDataModel)))
                return;

            var result = await MongoCollection.DeleteOneAsync(q => q.Id == id);
        }

        public async Task<TDataModel> GetByIdAsync(Guid dataModelId)
        {
            if (!typeof(IMongoDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q => 
                q.DataModelId == dataModelId.ToString());

            return await findResult.FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetAllAsync()
        {
            var findResult = await MongoCollection.FindAsync(q => true);

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> FindAsync(Expression<Func<TDataModel, bool>> expression)
        {
            var findResult = await MongoCollection.FindAsync(expression);

            return await findResult.ToListAsync();
        }

        public async Task<IEnumerable<TDataModel>> GetActivesAsync()
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IActivableDataModel)q).IsActive);

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetInactivesAsync()
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                !((IActivableDataModel)q).IsActive);

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByActivationUserAsync(string activationUser)
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IActivableDataModel)q).ActivationUser == activationUser);

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByActivationDateAsync(DateTime startDate, DateTime endDate)
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IActivableDataModel)q).ActivationDate.GetValueOrDefault().IsBetween(startDate, endDate));

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByInactivationUserAsync(string inactivationUser)
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IActivableDataModel)q).InactivationUser == inactivationUser);

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByInactivationDateAsync(DateTime startDate, DateTime endDate)
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IActivableDataModel)q).InactivationDate.GetValueOrDefault().IsBetween(startDate, endDate));

            return await findResult.ToListAsync();
        }

        public async Task<IEnumerable<TDataModel>> GetByRegistryVersionAsync(byte[] lastRegistryVersion)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IAuditableDataModel)q).RegistryVersion.IsGreaterThan(lastRegistryVersion));

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByCreatedUserAsync(string createdUser)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IAuditableDataModel)q).CreatedUser == createdUser);

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByCreatedDateAsync(DateTime startDate, DateTime endDate)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IAuditableDataModel)q).CreatedDate.IsBetween(startDate, endDate));

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByCreatedUserAndDateAsync(string createdUser, DateTime startDate, DateTime endDate)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IAuditableDataModel)q).CreatedUser == createdUser
                && ((IAuditableDataModel)q).CreatedDate.IsBetween(startDate, endDate));

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByUpdatedUserAsync(string updatedUser)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IAuditableDataModel)q).UpdatedUser == updatedUser);

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByUpdatedDateAsync(DateTime startDate, DateTime endDate)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IAuditableDataModel)q).UpdatedDate.GetValueOrDefault().IsBetween(startDate, endDate));

            return await findResult.ToListAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByUpdatedUserAndDateAsync(string updatedUser, DateTime startDate, DateTime endDate)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            var findResult = await MongoCollection.FindAsync(q =>
                ((IAuditableDataModel)q).UpdatedUser == updatedUser
                && ((IAuditableDataModel)q).UpdatedDate.GetValueOrDefault().IsBetween(startDate, endDate));

            return await findResult.ToListAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


