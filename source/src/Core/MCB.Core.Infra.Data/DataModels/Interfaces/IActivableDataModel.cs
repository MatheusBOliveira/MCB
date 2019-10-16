using System;

namespace MCB.Core.Infra.Data.DataModels.Interfaces
{
    public interface IActivableDataModel
        : IDataModel
    {
        bool IsActive { get; set; }

        string ActivationUser { get; set; }
        DateTime? ActivationDate { get; set; }

        string InactivationUser { get; set; }
        DateTime? InactivationDate { get; set; }
    }
}


