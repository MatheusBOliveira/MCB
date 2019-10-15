using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Core.Infra.Data.Repositories.Interfaces
{
    public interface IActivableRepository<T>
        : IRepository<T>
    {
        Task<IEnumerable<T>> GetActivesAsync();
        Task<IEnumerable<T>> GetInactivesAsync();
        Task<IEnumerable<T>> GetByActivationUserAsync(string activationUser);
        Task<IEnumerable<T>> GetByActivationDateAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<T>> GetByInactivationUserAsync(string inactivationUser);
        Task<IEnumerable<T>> GetByInactivationDateAsync(DateTime startDate, DateTime endDate);
    }
}


