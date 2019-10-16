using MCB.Core.Infra.Data.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCB.Core.Infra.Data.EFCore.Mappings
{
    public class DataModelMap
    {
        public virtual void Configure(EntityTypeBuilder builder)
        {
            builder.HasKey(nameof(DataModelBase.Id));
            builder.Property(nameof(DataModelBase.Id))
                .ValueGeneratedNever();
        }
    }
}


