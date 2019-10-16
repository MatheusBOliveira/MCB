namespace MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces
{
    public interface IFactoryWithParameter<T, TInputParameter>
        : IFactory<T>
    {
        T Create(TInputParameter parameter);
    }
}


