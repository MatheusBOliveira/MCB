using System;
using System.Collections.Generic;
using System.Reflection;

namespace MCB.Core.Infra.CrossCutting.Utils
{
    public class Utils
    {
        public IEnumerable<Type> GetTypesWithAttribute<T>(Assembly[] assemblies = null)
            where T : Attribute
        {
            if (assemblies == null)
                assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
                foreach (var type in assembly.GetTypes())
                    if (type.GetCustomAttributes(typeof(T), true).Length > 0)
                        yield return type;
        }
        public IEnumerable<Type> GetTypesThatAssingFrom<T>(Assembly[] assemblies = null, bool isGenericType = false)
        {
            if (assemblies == null)
                assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
                foreach (var type in assembly.GetTypes())
                    if (!isGenericType)
                        if (typeof(T).IsAssignableFrom(type))
                            yield return type;
                    else
                        if (type.IsGenericType
                            && type.GetGenericTypeDefinition() == typeof(T))
                            yield return type;
        }
    }
}


