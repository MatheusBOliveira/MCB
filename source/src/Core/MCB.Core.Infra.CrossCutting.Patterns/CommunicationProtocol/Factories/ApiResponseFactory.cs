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
        public override ApiResponse Create(CultureInfo cultureInfo)
        {
            return new ApiResponse();
        }

        public ApiResponse Create(CultureInfo cultureInfo, ApiRequest parameter)
        {
            var apiResponse = Create(cultureInfo);

            apiResponse.Header = parameter.Header.Clone();

            return apiResponse;
        }
    }
}


