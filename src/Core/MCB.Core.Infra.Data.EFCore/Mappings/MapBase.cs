using MCB.Core.Infra.Data.DataModels;
using MCB.Core.Infra.Data.DataModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCB.Core.Infra.Data.EFCore.Mappings
{
    public abstract class MapBase<TDataModel>
        : IEntityTypeConfiguration<TDataModel>
        where TDataModel : DataModelBase
    {
        public void Configure(EntityTypeBuilder<TDataModel> builder)
        {
            if (typeof(IDataModel).IsAssignableFrom(typeof(TDataModel)))
                new DataModelMap().Configure(builder);

            if (typeof(IActivableDataModel).IsAssignableFrom(typeof(TDataModel)))
                new ActivableDataModelMap().Configure(builder);

            if (typeof(IAuditableDataModel).IsAssignableFrom(typeof(TDataModel)))
                new AuditableDataModelMap().Configure(builder);

            builder.ToTable(GetTableName(), GetSchemaName());

            ConfigureMap(builder);
        }

        protected abstract string GetSchemaName();
        protected abstract string GetTableName();

        public abstract void ConfigureMap(EntityTypeBuilder<TDataModel> builder);
    }
}


