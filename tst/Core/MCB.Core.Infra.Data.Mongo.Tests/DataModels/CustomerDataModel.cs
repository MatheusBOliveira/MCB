using MCB.Core.Infra.Data.DataModels.Interfaces;
using MCB.Core.Infra.Data.Mongo.DataModels;
using MCB.Core.Infra.Data.Mongo.DataModels.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MCB.Core.Infra.Data.Mongo.Tests.DataModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    [BsonDiscriminator("Customer")]
    public class CustomerDataModel
        : DataModelBase,
        IMongoDataModel,
        IAuditableDataModel,
        IActivableDataModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string DataModelId { get; set; }
        public string Name { get; set; }

        public List<AppointmentDataModel> AppointmentCollection { get; set; }

        public bool IsActive { get; set; }
        public string ActivationUser { get; set; }
        public DateTime? ActivationDate { get; set; }
        public string InactivationUser { get; set; }
        public DateTime? InactivationDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte[] RegistryVersion { get; set; }
    }
}


