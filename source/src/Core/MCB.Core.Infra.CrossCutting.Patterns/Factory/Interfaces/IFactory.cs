using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces
{
    public interface IFactory<T>
    {
        T Create(CultureInfo culture);
    }
}


