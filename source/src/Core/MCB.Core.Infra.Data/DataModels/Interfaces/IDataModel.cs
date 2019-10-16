using System;
using System.Collections.Generic;

namespace MCB.Core.Infra.Data.DataModels.Interfaces
{
    public interface IDataModel
        : IDisposable
    {
        Guid Id { get; set; }

        IEnumerable<string> GetPropertyChangedCollection();
    }
}


