using MCB.Core.Domain.DomainModels.Interfaces;
using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using MCB.Core.Infra.CrossCutting.Patterns.Adapter;

namespace MCB.Core.Domain.Adapters
{
    public abstract class DomainModelAdapterBase
        : AdapterBase
    {
        protected void Adapt<TTarget, TSource>(TTarget target, TSource source)
        {
            if (typeof(IDomainModel).IsAssignableFrom(typeof(TTarget))
                && typeof(IDomainModel).IsAssignableFrom(typeof(TSource)))
                AdaptDomainModelBase((IDomainModel)target, (IDomainModel)source);

            if (typeof(IAuditableDomainModel).IsAssignableFrom(typeof(TTarget))
                && typeof(IAuditableDomainModel).IsAssignableFrom(typeof(TSource)))
                AdaptAuditableDomainModelBase((IAuditableDomainModel)target, (IAuditableDomainModel)source);

            if (typeof(IActivableDomainModel).IsAssignableFrom(typeof(TTarget))
                && typeof(IActivableDomainModel).IsAssignableFrom(typeof(TSource)))
                AdaptActivableDomainModelBase((IActivableDomainModel)target, (IActivableDomainModel)source);
        }

        private void AdaptDomainModelBase(IDomainModel source, IDomainModel target)
        {
            source.DomainModel.Id = target.DomainModel.Id;
        }
        private void AdaptAuditableDomainModelBase(IAuditableDomainModel source, IAuditableDomainModel target)
        {
            source.AuditableInfo = target.AuditableInfo.Clone();
        }
        private void AdaptActivableDomainModelBase(IActivableDomainModel source, IActivableDomainModel target)
        {
            source.ActivableInfo = target.ActivableInfo.Clone();
        }
    }
}


