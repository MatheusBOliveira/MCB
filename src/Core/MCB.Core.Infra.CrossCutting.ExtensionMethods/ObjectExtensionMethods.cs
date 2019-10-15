using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods
{
    public static class ObjectExtensionMethods
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings;

        static ObjectExtensionMethods()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public static string SerializeToJson(this object obj, bool preserveReference = false)
        {
            if (preserveReference)
                return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
            else
                return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }
}


