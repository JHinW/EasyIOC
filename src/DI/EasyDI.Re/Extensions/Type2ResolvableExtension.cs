using EasyDI.Core;
using EasyDI.Re.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.Re.Extensions
{
    public static class Type2ResolvableExtension
    {
        public static ResolvableTypeDef AsResolvableType(this Type baseType, IResolver resolver)
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
                return new ResolvableTypeDef
                {
                    OriginalType = baseType,
                    ResolvableType = baseType,
                    IsEnumrableType = false,
                    IsGenericType = false,
                    GenericsDependencies = null,
                    EasyTypeDescriptorItem = resolver.DecriptorResolve(baseType)
                };
            }

            if (baseType.IsGenericType)
            {
                var capType = baseType.GetGenericTypeDefinition();
                if (resolver.CanBeResolved(capType))
                {
                    return new ResolvableTypeDef
                    {
                        OriginalType = baseType,
                        ResolvableType = capType,
                        IsEnumrableType = false,
                        IsGenericType = true,
                        GenericsDependencies = capType.GetGenericArguments(),
                        EasyTypeDescriptorItem = resolver.DecriptorResolve(capType)
                    };

                }

                if (typeof(IEnumerable).IsAssignableFrom(baseType))
                {
                    var clonedGenerics = baseType.GetGenericArguments();
                    if (clonedGenerics.Length == 1)
                    {
                        var realBaseType = clonedGenerics[0];
                        if (resolver.CanBeResolved(realBaseType))
                        {
                            return new ResolvableTypeDef
                            {
                                OriginalType = baseType,
                                ResolvableType = realBaseType,
                                IsEnumrableType = true,
                                IsGenericType = true,
                                GenericsDependencies = null,
                                EasyTypeDescriptorItem = resolver.DecriptorResolve(realBaseType)
                            };
                        }
                    }
                }
            }

            throw new InvalidOperationException($"Error: Type: {baseType} Can not be resolved.");
        }
    }
}
