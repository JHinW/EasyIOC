using EasyDI.Core;
using EasyDI.Re.Definitions;
using EasyDI.Re.Extensions;
using System;
using System.Collections;
using static EasyDI.Core.Delegates;

namespace EasyDI.Re.Statics
{
    public static class TypeResolveHelper
    {
        public static ResolvableTypeDef BaseTypeResolve(Type baseType, IResolver resolver)
        {
            if (!resolver.IsResolving(baseType))
            {
                resolver.AddToScopeSet(baseType);
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
            else
            {
                throw new InvalidOperationException("Error: Circular Dependency.");
            }
        }


        public static ResolvableTypeDef GenericBaseResolve(Type baseType, IResolver resolver)
        {
            var capType = baseType.GetGenericTypeDefinition();
            if (resolver.CanBeResolved(capType))
            {
                if (resolver.IsResolving(capType))
                {
                    throw new InvalidOperationException("Error: Circular Dependency.");
                }
                else
                {
                    resolver.AddToScopeSet(capType);
                    return new ResolvableTypeDef
                    {
                        OriginalType = baseType,
                        ResolvableType = capType,
                        IsEnumrableType = false,
                        IsGenericType = true,
                        GenericsDependencies = baseType.GetGenericArguments(),
                        EasyTypeDescriptorItem = resolver.DecriptorResolve(capType)
                    };
                }
            }

            return null;
        }

        public static ResolvableTypeDef GenericEnumrableResolve(Type baseType, IResolver resolver)
        {
            var clonedGenerics = baseType.GetGenericArguments();
            if (clonedGenerics.Length == 1)
            {
                var realBaseType = clonedGenerics[0];
                if (resolver.CanBeResolved(realBaseType))
                {
                    if (resolver.IsResolving(realBaseType))
                    {
                        throw new InvalidOperationException("Error: Circular Dependency.");
                    }
                    else
                    {
                        resolver.AddToScopeSet(realBaseType);
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

            return null;
        }
    }
}
