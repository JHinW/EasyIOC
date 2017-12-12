

namespace EasyDI.Resolve.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Statics;

    public static class TypeExtension
    {
        public static IResolve AsResolve(this Type type, Func<Type, bool> checker)
        {
            return ResolveHelper.ResolveBuild(type, checker);
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
