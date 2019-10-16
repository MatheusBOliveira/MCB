using MCB.Core.Infra.Data.EFCore.Contexts.Interfaces;
using MCB.Core.Infra.Data.EFCore.UnitOfWork;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Tests.UoW
{
    public class UnitOfWork
        : EFUnitOfWork
    {
        public UnitOfWork(IDbContext context) 
            : base(context)
        {

        }
    }
}


