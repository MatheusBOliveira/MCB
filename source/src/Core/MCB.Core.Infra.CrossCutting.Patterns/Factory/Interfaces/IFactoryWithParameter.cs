using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces
{
    public interface IFactoryWithParameter<T, TInputParameter>
        : IFactory<T>
    {
        T Create(CultureInfo culture, TInputParameter parameter);
    }
}


