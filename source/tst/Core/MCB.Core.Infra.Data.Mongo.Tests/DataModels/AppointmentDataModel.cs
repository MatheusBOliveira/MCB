using MCB.Core.Infra.Data.DataModels.Interfaces;
using MCB.Core.Infra.Data.Mongo.DataModels;
using MCB.Core.Infra.Data.Mongo.DataModels.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MCB.Core.Infra.Data.Mongo.Tests.DataModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    [BsonDiscriminator("Appointment")]
    public class AppointmentDataModel
        : DataModelBase,
        IMongoDataModel,
        IAuditableDataModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string DataModelId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Observation { get; set; }


        public CustomerDataModel Customer { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte[] RegistryVersion { get; set; }
    }
}


