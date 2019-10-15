using MCB.Core.Infra.CrossCutting.ExtensionMethods;
using MCB.Core.Infra.CrossCutting.Globalization.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Globalization
{
    public class GlobalizationManager
    {
        private readonly List<GlobalizationMessages> _globalizationMessagesCollection;

        public GlobalizationManager()
        {
            _globalizationMessagesCollection = new List<GlobalizationMessages>();
        }

        public void LoadGlobalizationMessages()
        {
            _globalizationMessagesCollection.Clear();

            var filesCollection =
                new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)
                .GetFiles("*.globalization.json");

            foreach (var file in filesCollection)
            {
                var fileContent = string.Empty;

                using (var sr = new StreamReader(file.FullName, Encoding.Default))
                    fileContent = sr.ReadToEnd();

                _globalizationMessagesCollection.AddRange(
                    fileContent.DeserializeFromJson<List<GlobalizationMessages>>().ToArray());
            }
        }

        public string GetMessage(string code, string language)
        {
            var message =
                _globalizationMessagesCollection.FirstOrDefault(q => q.Code.ToUpper().Equals(code.ToUpper()))
                ?.Messages
                ?.FirstOrDefault(q => q.Key.ToLower().Equals((language ?? "en-US").ToLower()))
                .Value;

            return message ?? code;
        }
    }
}


