using MCB.Core.Infra.Data.EFCore.Mappings;
using MCB.Core.Infra.Data.EFCore.InMemory.Tests.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCB.Core.Infra.Data.EFCore.InMemory.Tests.Mappings
{
    public class AppointmentDataModelMap
        : MapBase<AppointmentDataModel>
    {
        protected override string GetSchemaName() => "public";
        protected override string GetTableName() => "appointment";

        public override void ConfigureMap(EntityTypeBuilder<AppointmentDataModel> builder)
        {
            builder.Property(q => q.CustomerId)
                .IsRequired();

            builder.Property(q => q.Date)
                .IsRequired();

            builder.HasIndex(q => q.CustomerId);
            builder.HasIndex(q => q.Date);
            builder.HasIndex(q => new { q.CustomerId, q.Date });

            builder.Property(q => q.Observation)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.HasOne(q => q.Customer)
                .WithMany(q => q.AppointmentCollection)
                .HasForeignKey(q => q.CustomerId);
        }
    }
}


