using MCB.Core.Infra.Data.DataModels;
using MCB.Core.Infra.Data.DataModels.Interfaces;
using System;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Tests.DataModels
{
    public class AppointmentDataModel
        : DataModelBase,
        IAuditableDataModel
    {
        public Guid CustomerId { get; set; }
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


