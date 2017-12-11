

namespace EasyDI.Resolve.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;

    public static class TypeExtension
    {
        public static IResolve AsResolve(this Type type)
        {

            return null;
        }

        public static IEnumerable<Type> GenericFlatten(this Type type)
        {
            var genericType = type.GetGenericTypeDefinition();
            yield return genericType;
            foreach(var argType in type.GetGenericArguments())
            {
                yield return argType;

            }
        }

    }
}
