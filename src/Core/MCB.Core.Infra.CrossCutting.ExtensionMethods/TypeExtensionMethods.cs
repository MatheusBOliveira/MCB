using System;
using System.Linq;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods
{
    public static class TypeExtensionMethods
    {
        public static TAttribute GetAttribute<TAttribute>(this Type obj)
            where TAttribute : Attribute
        {
            var attribute = (TAttribute)
                obj.GetCustomAttributes(true)
                .FirstOrDefault(q => q is TAttribute);

            return attribute;
        }
    }
}


