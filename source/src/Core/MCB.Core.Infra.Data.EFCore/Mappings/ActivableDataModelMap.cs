using MCB.Core.Infra.Data.DataModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCB.Core.Infra.Data.EFCore.Mappings
{
    public class ActivableDataModelMap
    {
        public virtual void Configure(EntityTypeBuilder builder)
        {
            var isActiveField = nameof(IActivableDataModel.IsActive);
            var activationUserField = nameof(IActivableDataModel.ActivationUser);
            var activationDateField = nameof(IActivableDataModel.ActivationDate);

            var inactivationUserField = nameof(IActivableDataModel.InactivationUser);
            var inactivationDateField = nameof(IActivableDataModel.InactivationDate);


            builder.Property(isActiveField)
                .HasColumnName(isActiveField)
                .IsRequired();
            builder.HasIndex(isActiveField);

            builder.Property(activationUserField)
                .HasColumnName(activationUserField)
                .IsRequired(false)
                .HasMaxLength(150);
            builder.HasIndex(activationUserField);

            builder.Property(activationDateField)
                .HasColumnName(activationDateField)
                .IsRequired(false);
            builder.HasIndex(activationDateField);

            builder.Property(inactivationUserField)
                .HasColumnName(inactivationUserField)
                .IsRequired(false)
                .HasMaxLength(150);
            builder.HasIndex(inactivationUserField);

            builder.Property(inactivationDateField)
                .HasColumnName(inactivationDateField)
                .IsRequired(false);
            builder.HasIndex(inactivationDateField);
        }
    }
}


