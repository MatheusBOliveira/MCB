using MCB.Core.Domain.ValueObjects;
using MCB.Core.Infra.Data.EFCore.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MCB.Core.Infra.Data.EFCore.Contexts
{
    public abstract class ContextBase
        : DbContext,
        IDbContext        
    {
        protected string ConnectionString { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EmailValueObject>();
            modelBuilder.Ignore<PasswordValueObject>();
            modelBuilder.Ignore<PhoneNumberValueObject>();

            /*
             * ApplyMappings() methods must have call before
             * DeleteBehavior manipulation
             */
            ApplyMappings(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;


            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            ConnectionString = ConfigureConnectionString();
            Configure(optionsBuilder);
        }

        public abstract string ConfigureConnectionString();
        public abstract void Configure(DbContextOptionsBuilder optionsBuilder);
        public abstract void ApplyMappings(ModelBuilder modelBuilder);
    }
}


