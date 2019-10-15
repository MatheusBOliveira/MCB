using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using MCB.Core.Infra.Data.DataModels;
using MCB.Core.Infra.Data.DataModels.Interfaces;
using MCB.Core.Infra.Data.EFCore.Contexts.Interfaces;
using MCB.Core.Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MCB.Core.Infra.Data.EFCore.Repositories
{
    public abstract class RepositoryBase<TDataModel>
        : IRepository<TDataModel>,
        IActivableRepository<TDataModel>,
        IAuditableRepository<TDataModel>
        where TDataModel : DataModelBase
    {
        private readonly IDbContext _context;
        private readonly DbSet<TDataModel> _dbSet;

        protected DbSet<TDataModel> DbSet
        {
            get
            {
                return _dbSet;
            }
        }

        public RepositoryBase(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TDataModel>();
        }

        private void SetModifiedProperties(EntityEntry<TDataModel> entry, TDataModel dataModel)
        {
            var changedProperties = dataModel.GetPropertyChangedCollection();

            if (changedProperties == null
                || !changedProperties.Any())
                return;

            foreach (var property in entry.Properties)
                property.IsModified =
                    changedProperties.Contains(
                        property.Metadata.PropertyInfo.Name);
        }

        public async Task<TDataModel> AddAsync(TDataModel dataModel)
        {
            if(dataModel is IAuditableDataModel auditableDataModel)
            {
                auditableDataModel.RegistryVersion =
                    BitConverter.GetBytes(DateTime.UtcNow.Ticks);
            }

            var entry = await _dbSet.AddAsync(dataModel);

            return entry.Entity;
        }
        public async Task<TDataModel> UpdateAsync(TDataModel dataModel)
        {
            if (dataModel is IAuditableDataModel auditableDataModel)
            {
                if(auditableDataModel != null)
                    auditableDataModel.RegistryVersion =
                        BitConverter.GetBytes(DateTime.UtcNow.Ticks);
            }

            var entry = _context.Entry(dataModel);
            entry.State = EntityState.Modified;
            SetModifiedProperties(entry, dataModel);

            return await Task.FromResult(entry.Entity);
        }
        public Task RemoveAsync(Guid id)
        {
            var dataModel = Activator.CreateInstance<TDataModel>();
            dataModel.Id = id;

            _dbSet.Remove(dataModel);

            return Task.CompletedTask;
        }
        public async Task<TDataModel> GetByIdAsync(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<TDataModel>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> FindAsync(Expression<Func<TDataModel, bool>> expression)
        {
            return await 
                _dbSet.AsNoTracking().Where(expression).ToArrayAsync();
        }

        public async Task<IEnumerable<TDataModel>> GetByCreatedDateAsync(DateTime startDate, DateTime endDate)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q =>
                    ((IAuditableDataModel)q).CreatedDate.IsBetween(startDate, endDate)
                ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByCreatedUserAsync(string createdUser)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q =>
                ((IAuditableDataModel)q).CreatedUser.Equals(createdUser)
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByCreatedUserAndDateAsync(string createdUser, DateTime startDate, DateTime endDate)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q =>
                ((IAuditableDataModel)q).CreatedUser.Equals(createdUser)
                && ((IAuditableDataModel)q).CreatedDate.IsBetween(startDate, endDate)
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByUpdatedDateAsync(DateTime startDate, DateTime endDate)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q =>
                ((IAuditableDataModel)q).UpdatedDate.GetValueOrDefault().IsBetween(startDate, endDate)
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByUpdatedUserAsync(string updatedUser)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q =>
                ((IAuditableDataModel)q).UpdatedUser == updatedUser
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByUpdatedUserAndDateAsync(string updatedUser, DateTime startDate, DateTime endDate)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q =>
                ((IAuditableDataModel)q).UpdatedUser == updatedUser
                && ((IAuditableDataModel)q).UpdatedDate.GetValueOrDefault().IsBetween(startDate, endDate)
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByRegistryVersionAsync(byte[] lastRegistryVersion)
        {
            if (!typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q => 
                ((IAuditableDataModel)q).RegistryVersion.IsGreaterThan(lastRegistryVersion)
            ).ToArrayAsync();
        }

        public async Task<IEnumerable<TDataModel>> GetActivesAsync()
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q => 
                ((IActivableDataModel)q).IsActive
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByActivationDateAsync(DateTime startDate, DateTime endDate)
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q =>
                ((IActivableDataModel)q).ActivationDate.GetValueOrDefault().IsBetween(startDate, endDate)
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByActivationUserAsync(string activationUser)
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q => 
                ((IActivableDataModel)q).ActivationUser == activationUser
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByInactivationDateAsync(DateTime startDate, DateTime endDate)
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q =>
                ((IActivableDataModel)q).InactivationDate.GetValueOrDefault().IsBetween(startDate, endDate)
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetByInactivationUserAsync(string inactivationUser)
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q => 
                ((IActivableDataModel)q).InactivationUser == inactivationUser
            ).ToArrayAsync();
        }
        public async Task<IEnumerable<TDataModel>> GetInactivesAsync()
        {
            if (!typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                return default;

            return await DbSet.AsNoTracking().Where(q => 
                !((IActivableDataModel)q).IsActive
            ).ToArrayAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


