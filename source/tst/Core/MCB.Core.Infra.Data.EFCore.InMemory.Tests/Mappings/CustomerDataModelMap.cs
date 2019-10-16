using MCB.Core.Infra.Data.EFCore.Mappings;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Tests.Mappings
{
    public class CustomerDataModelMap
        : MapBase<CustomerDataModel>
    {
        protected override string GetSchemaName() => "public";
        protected override string GetTableName() => "customer";

        public override void ConfigureMap(EntityTypeBuilder<CustomerDataModel> builder)
        {
            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(150);
            builder.HasIndex(q => q.Name);
        }

        
    }
}


