using Newtonsoft.Json;
using System;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings;

        static StringExtensionMethods()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
        }

        public static T DeserializeFromJson<T>(this string str)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(str, _jsonSerializerSettings);
            }
            catch (Exception)
            {
                return default;
            }
        }
        public static bool LengthIsBetween(this string str, int min, int max)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            return str.Length >= min && str.Length <= max;
        }
        public static string GetOnlyNumericDigits(this string str)
        {
            var sb = new StringBuilder();

            foreach (var character in str)
                if (char.IsDigit(character))
                    sb.Append(character);

            return sb.ToString();
        }
    }
}


