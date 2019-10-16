using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using MCB.Core.Infra.CrossCutting.Patterns.Factory;
using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.Factories
{
    public class ApiResponseFactory
        : FactoryBase<ApiResponse>,
        IFactoryWithParameter<ApiResponse, ApiRequest>
    {
        public override ApiResponse Create()
        {
            return new ApiResponse();
        }

        public ApiResponse Create(ApiRequest parameter)
        {
            var apiResponse = Create();

            apiResponse.Header = parameter.Header.Clone();

            return apiResponse;
        }
    }
}


