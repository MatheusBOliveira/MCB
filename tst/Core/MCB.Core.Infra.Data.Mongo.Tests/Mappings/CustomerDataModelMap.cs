using MCB.Core.Infra.Data.Mongo.Mappings;
using MCB.Core.Infra.Data.Mongo.Tests.DataModels;
using MongoDB.Bson.Serialization;

namespace MCB.Core.Infra.Data.Mongo.Tests.Mappings
{
    public class CustomerDataModelMap
        : MapBase<CustomerDataModel>
    {
        public CustomerDataModelMap(BsonClassMap<CustomerDataModel> classMap) 
            : base(classMap)
        {

        }

        public override void Map(BsonClassMap<CustomerDataModel> classMap)
        {
            classMap.MapProperty(q => q.Name)
                    .SetIsRequired(true);

            classMap.MapMember(q => q.AppointmentCollection)
                    .SetIsRequired(false);
        }
    }
}


