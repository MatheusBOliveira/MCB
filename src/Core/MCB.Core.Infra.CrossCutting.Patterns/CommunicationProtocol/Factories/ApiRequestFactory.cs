using MCB.Core.Infra.CrossCutting.Patterns.Factory;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.Factories
{
    public class ApiRequestFactory
        : FactoryBase<ApiRequest>
    {
        public override ApiRequest Create()
        {
            return new ApiRequest();
        }
    }
}


