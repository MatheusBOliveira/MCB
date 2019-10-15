using System;

namespace MCB.Core.Infra.Data.DataModels.Interfaces
{
    public interface IAuditableDataModel
        : IDataModel
    {
        string CreatedUser { get; set; }
        DateTime CreatedDate { get; set; }
        string UpdatedUser { get; set; }
        DateTime? UpdatedDate { get; set; }
        byte[] RegistryVersion { get; set; }
    }
}


