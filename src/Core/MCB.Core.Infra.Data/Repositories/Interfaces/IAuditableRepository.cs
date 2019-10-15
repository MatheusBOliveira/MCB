using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCB.Core.Infra.Data.Repositories.Interfaces
{
    public interface IAuditableRepository<T>
        : IRepository<T>
    {
        Task<IEnumerable<T>> GetByRegistryVersionAsync(byte[] lastRegistryVersion);
        Task<IEnumerable<T>> GetByCreatedUserAsync(string createdUser);
        Task<IEnumerable<T>> GetByCreatedDateAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<T>> GetByCreatedUserAndDateAsync(string createdUser, DateTime startDate, DateTime endDate);
        Task<IEnumerable<T>> GetByUpdatedUserAsync(string updatedUser);
        Task<IEnumerable<T>> GetByUpdatedDateAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<T>> GetByUpdatedUserAndDateAsync(string updatedUser, DateTime startDate, DateTime endDate);
    }
}


