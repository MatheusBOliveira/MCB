using MCB.Core.Infra.Data.DataModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCB.Core.Infra.Data.EFCore.Mappings
{
    public class AuditableDataModelMap
    {
        public virtual void Configure(EntityTypeBuilder builder)
        {
            var creationUserField = nameof(IAuditableDataModel.CreatedUser);
            var creationDateField = nameof(IAuditableDataModel.CreatedDate);
            var modificationUserField = nameof(IAuditableDataModel.UpdatedUser);
            var modificationDateField = nameof(IAuditableDataModel.UpdatedDate);
            var registryVersionDateField = nameof(IAuditableDataModel.RegistryVersion);

            builder.Property(creationUserField)
                    .HasColumnName(creationUserField)
                    .IsRequired()
                    .HasMaxLength(150);
            builder.HasIndex(creationUserField);

            builder.Property(creationDateField)
                .HasColumnName(creationDateField)
                .IsRequired();
            builder.HasIndex(creationDateField);

            builder.Property(modificationUserField)
                .HasColumnName(modificationUserField)
                .IsRequired(false)
                .HasMaxLength(150);
            builder.HasIndex(modificationUserField);

            builder.Property(modificationDateField)
                .HasColumnName(modificationDateField)
                .IsRequired(false);
            builder.HasIndex(modificationDateField);

            builder.Property(registryVersionDateField)
                .HasColumnName(registryVersionDateField)
                .IsRequired();

            builder.HasIndex(registryVersionDateField);
        }
    }
}


