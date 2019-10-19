using MCB.Core.Infra.CrossCutting.Configuration;
using MCB.Core.Infra.CrossCutting.Configuration.Interfaces;
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
        private readonly IConfigurationManager _configuration;

        public TestContext(IConfigurationManager configuration)
        {
            _configuration = configuration;
        }

        public override string ConfigureConnectionString()
        {
            return _configuration.Get("ConnectionStrings.DefaultConnection");
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
                var config = new ConfigurationManager();
                config.LoadConfigurations();

                return new TestContext(config);
            }
        }
    }
}


