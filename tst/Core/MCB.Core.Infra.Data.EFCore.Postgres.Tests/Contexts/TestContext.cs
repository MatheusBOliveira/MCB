using MCB.Core.Infra.Data.EFCore.Postgres.Contexts;
using MCB.Core.Infra.Data.EFCore.Postgres.Tests.DataModels;
using MCB.Core.Infra.Data.EFCore.Postgres.Tests.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace MCB.Core.Infra.Data.EFCore.Postgres.Tests.Contexts
{
    public class TestContext
        : PostgresContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<CustomerDataModel> CustomerDbSet { get; set; }
        public DbSet<AppointmentDataModel> AppointmentDbSet { get; set; }

        public TestContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override string ConfigureConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public override void ApplyMappings(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerDataModelMap());
            modelBuilder.ApplyConfiguration(new AppointmentDataModelMap());
        }

        public class TestContextFactory : IDesignTimeDbContextFactory<TestContext>
        {
            public TestContext CreateDbContext(string[] args)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();


                return new TestContext(config);
            }
        }
    }
}


