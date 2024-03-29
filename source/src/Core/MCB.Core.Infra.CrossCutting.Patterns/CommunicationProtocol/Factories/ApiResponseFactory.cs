using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using System.Globalization;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.Factories
{
    public class ApiResponseFactory
        : FactoryBase<ApiResponse>,
        IFactoryWithParameter<ApiResponse, ApiRequest>
    {
        public override ApiResponse Create(CultureInfo culture)
        {
            return new ApiResponse();
        }

        public ApiResponse Create(ApiRequest parameter, CultureInfo culture)
        {
            var apiResponse = Create(culture);

            apiResponse.Header = parameter.Header.Clone();

            return apiResponse;
        }
    }
}


