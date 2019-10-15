using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MCB.Core.Infra.Data.Repositories.Interfaces
{
    public interface IRepository<T>
        : IDisposable
    {
        Task<T> AddAsync(T dataModel);
        Task<T> UpdateAsync(T dataModel);
        Task RemoveAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
    }
}


