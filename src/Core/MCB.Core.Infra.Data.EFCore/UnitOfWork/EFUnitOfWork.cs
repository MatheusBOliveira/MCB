using MCB.Core.Infra.CrossCutting.Patterns.UoW.Interfaces;
using MCB.Core.Infra.Data.EFCore.Contexts.Interfaces;
using System;
using System.Threading.Tasks;

namespace MCB.Core.Infra.Data.EFCore.UnitOfWork
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private readonly IDbContext _contextBase;

        public EFUnitOfWork(IDbContext contextBase)
        {
            _contextBase = contextBase;
        }

        public async Task<bool> CommitAsync()
        {
            return await _contextBase.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _contextBase.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}


