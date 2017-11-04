using EasyDI.Core;
using EasyDI.Re.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

            if (typeof(IEnumerable).IsAssignableFrom(baseType)
                && baseType.IsGenericType)
            {
                var clonedGenerics = baseType.GetGenericArguments();
                if (clonedGenerics.Length == 1)
                {
                    var realBaseType = clonedGenerics[0];
                    if (resolver.CanBeResolved(baseType))
                    {
                        return resolver
                            .DecriptorResolve(baseType)
                            .AsInstanceFactory(true);
                    }
                }
            }

            throw new InvalidOperationException($"Error: Type: {baseType} Can not be resolved.");
        }
    }
}
