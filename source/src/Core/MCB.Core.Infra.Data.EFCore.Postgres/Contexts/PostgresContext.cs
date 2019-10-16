using MCB.Core.Infra.Data.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MCB.Core.Infra.Data.EFCore.Postgres.Contexts
{
    public abstract class PostgresContext
        : ContextBase
    {
        public override void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString, options => {
                options.EnableRetryOnFailure(3);
            });
        }
    }
}


