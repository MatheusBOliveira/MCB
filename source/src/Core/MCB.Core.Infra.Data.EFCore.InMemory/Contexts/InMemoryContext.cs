using MCB.Core.Infra.Data.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Contexts
{
    public abstract class InMemoryContext
        : ContextBase
    {
        public override void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }
    }
}


