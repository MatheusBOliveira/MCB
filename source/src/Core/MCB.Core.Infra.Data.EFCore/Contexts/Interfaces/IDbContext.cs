using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCB.Core.Infra.Data.EFCore.Contexts.Interfaces
{
    public interface IDbContext
        : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}


