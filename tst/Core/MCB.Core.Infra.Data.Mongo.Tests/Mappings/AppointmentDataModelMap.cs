using MCB.Core.Infra.Data.Mongo.Mappings;
using MCB.Core.Infra.Data.Mongo.Tests.DataModels;
using MongoDB.Bson.Serialization;

namespace MCB.Core.Infra.Data.Mongo.Tests.Mappings
{
    public class AppointmentDataModelMap
        : MapBase<AppointmentDataModel>
    {
        public AppointmentDataModelMap(BsonClassMap<AppointmentDataModel> classMap) 
            : base(classMap)
        {
        }

        public override void Map(BsonClassMap<AppointmentDataModel> classMap)
        {
            classMap.MapProperty(q => q.CustomerId)
                .SetIsRequired(true);

            classMap.MapProperty(q => q.Date)
                .SetIsRequired(true);

            classMap.MapProperty(q => q.Observation)
                .SetIsRequired(false);

            classMap.MapMember(q => q.CustomerId)
                .SetIsRequired(true);
        }
    }
}


