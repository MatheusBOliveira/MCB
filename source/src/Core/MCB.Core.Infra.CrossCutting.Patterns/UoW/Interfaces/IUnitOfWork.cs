using System;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Patterns.UoW.Interfaces
{
    public interface IUnitOfWork
        : IDisposable
    {
        Task<bool> CommitAsync();
    }
}


