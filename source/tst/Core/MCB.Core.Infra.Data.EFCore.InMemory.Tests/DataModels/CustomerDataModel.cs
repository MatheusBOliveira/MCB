using MCB.Core.Infra.Data.DataModels;
using MCB.Core.Infra.Data.DataModels.Interfaces;
using System;
using System.Collections.Generic;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Tests.DataModels
{
    public class CustomerDataModel
        : DataModelBase,
        IAuditableDataModel,
        IActivableDataModel
    {
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


