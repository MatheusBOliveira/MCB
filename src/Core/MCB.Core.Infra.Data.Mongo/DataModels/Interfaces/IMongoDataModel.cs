using MCB.Core.Infra.Data.DataModels.Interfaces;

namespace MCB.Core.Infra.Data.Mongo.DataModels.Interfaces
{
    public interface IMongoDataModel
        : IDataModel
    {
        /*
         * This property is Domain Id. Because a mongo library convention,
         * the id member is a mongo key and we needed create a new key.
         * 
         * Because a limitation of mongo library, this property must be a 
         * string because the mongo library cannot compare Guid values.
         */
        string DataModelId { get; set; }
    }
}


