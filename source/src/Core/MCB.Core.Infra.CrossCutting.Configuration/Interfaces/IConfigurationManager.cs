using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Configuration.Interfaces
{
    public interface IConfigurationManager
        : IDisposable
    {
        string Get(string key);
        T Get<T>(string key);

        void Set(string key, object value);

        void LoadConfigurations();
    }
}
