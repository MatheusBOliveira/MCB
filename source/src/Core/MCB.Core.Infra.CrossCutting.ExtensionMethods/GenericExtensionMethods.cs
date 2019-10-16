namespace MCB.Core.Infra.CrossCutting.ExtensionMethods
{
    public static class GenericExtensionMethods
    {
        public static T Clone<T>(this T obj)
        {
            return obj.SerializeToJson().DeserializeFromJson<T>();
        }
    }
}


