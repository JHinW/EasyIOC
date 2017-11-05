using EasyDI.Core;
using EasyDI.Re.Extensions;
using System;
using System.Collections;
using static EasyDI.Core.Delegates;

namespace EasyDI.Re.Statics
{
    public static class TypeHelper
    {
        public static InstanceFactory BaseType2InstanceFactory(Type baseType, IResolver resolver)
        {
            if (resolver.IsResolving(baseType))
            {
                throw new InvalidOperationException("Error: Circular Dependency.");
            }
            else
            {
                resolver.AddToScopeSet(baseType);
            }

            if (resolver.CanBeResolved(baseType))
            {
                return resolver
                    .DecriptorResolve(baseType)
                    .AsInstanceFactory(false);
            }

            if (baseType.IsGenericType)
            {
                var capType = baseType.GetGenericTypeDefinition();
                if (resolver.CanBeResolved(capType))
                {

                }

                if (typeof(IEnumerable).IsAssignableFrom(baseType))
                {
                    var clonedGenerics = baseType.GetGenericArguments();
                    if (clonedGenerics.Length == 1)
                    {
                        var realBaseType = clonedGenerics[0];
                        if (resolver.CanBeResolved(realBaseType))
                        {
                            return resolver
                                .DecriptorResolve(realBaseType)
                                .AsInstanceFactory(true);
                        }
                    }
                }
            }

            throw new InvalidOperationException($"Error: Type: {baseType} Can not be resolved.");
        }
    }
}
