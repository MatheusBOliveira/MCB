using MCB.Core.Infra.Data.DataModels.Interfaces;
using MCB.Core.Infra.Data.Mongo.DataModels;
using MCB.Core.Infra.Data.Mongo.DataModels.Interfaces;
using MongoDB.Bson.Serialization;

namespace MCB.Core.Infra.Data.Mongo.Mappings
{
    public abstract class MapBase<T>
        where T : DataModelBase
    {
        public MapBase(BsonClassMap<T> classMap)
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(T)))
                return;

            MapDataModel(classMap);
            MapAuditableDataModel(classMap);
            MapActivableDataModel(classMap);

            Map(classMap);

            BsonClassMap.RegisterClassMap(classMap);
        }

        private void MapDataModel(BsonClassMap<T> classMap)
        {
            if (!typeof(IMongoDataModel).IsAssignableFrom(typeof(T)))
                return;

            classMap.MapIdProperty(nameof(IMongoDataModel.Id));
            classMap.MapProperty(nameof(IMongoDataModel.DataModelId))
                .SetIsRequired(true);
        }
        private void MapAuditableDataModel(BsonClassMap<T> classMap)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(T)))
                return;

            classMap.MapProperty(nameof(IAuditableDataModel.CreatedUser))
                .SetIsRequired(true);

            classMap.MapProperty(nameof(IAuditableDataModel.CreatedDate))
                    .SetIsRequired(true);

            classMap.MapProperty(nameof(IAuditableDataModel.UpdatedUser))
                    .SetIsRequired(false);

            classMap.MapProperty(nameof(IAuditableDataModel.UpdatedDate))
                    .SetIsRequired(false);

            classMap.MapProperty(nameof(IAuditableDataModel.RegistryVersion))
                    .SetIsRequired(true);
        }
        private void MapActivableDataModel(BsonClassMap<T> classMap)
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(T)))
                return;

            classMap.MapProperty(nameof(IActivableDataModel.IsActive))
                .SetIsRequired(true);

            classMap.MapProperty(nameof(IActivableDataModel.ActivationUser))
                .SetIsRequired(false);

            classMap.MapProperty(nameof(IActivableDataModel.ActivationDate))
                .SetIsRequired(false);

            classMap.MapProperty(nameof(IActivableDataModel.InactivationUser))
                .SetIsRequired(false);

            classMap.MapProperty(nameof(IActivableDataModel.InactivationDate))
                .SetIsRequired(false);
        }

        public abstract void Map(BsonClassMap<T> classMap);
    }
}


