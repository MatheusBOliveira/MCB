using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.Factories
{
    public class ApiRequestFactory
        : FactoryBase<ApiRequest>
    {
        public override ApiRequest Create(CultureInfo culture)
        {
            return new ApiRequest();
        }
    }
}


