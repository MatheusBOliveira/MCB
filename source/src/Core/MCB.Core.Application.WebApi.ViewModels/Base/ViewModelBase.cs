using MCB.Core.Application.WebApi.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Application.WebApi.ViewModels.Base
{
    public abstract class ViewModelBase
        : IViewModel
    {
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
