using MCB.Core.Infra.CrossCutting.Globalization.Interfaces;
using System.Reflection;

namespace MCB.Core.Infra.CrossCutting.Globalization
{
    public abstract class GlobalizationConfigBase
        : IGlobalizationConfig
    {
        public string GlobalizationRelativeFileName =>
            $"{Assembly.GetExecutingAssembly().FullName}.globalization.json";
    }
}


