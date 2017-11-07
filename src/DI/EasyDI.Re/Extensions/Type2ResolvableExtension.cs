using EasyDI.Core;
using EasyDI.Re.Definitions;
using EasyDI.Re.Statics;
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
            ResolvableTypeDef ret = null;

            #region Resolve the original type

            if (resolver.CanBeResolved(baseType))
            {
                ret =  TypeResolveHelper.BaseTypeResolve(baseType, resolver);
            }

            #endregion

            #region Try to resolve the generic type

            if (baseType.IsGenericType)
            {
                ret =  TypeResolveHelper.GenericBaseResolve(baseType, resolver);

                #region Try to resolve the IEnumerable type

                if (typeof(IEnumerable).IsAssignableFrom(baseType))
                {
                    ret =  TypeResolveHelper.GenericEnumrableResolve(baseType, resolver);
                }

                # endregion
            }

            #endregion

            return ret ?? throw new InvalidOperationException($"Error: Type: {baseType} Can not be resolved.");
        }
    }
}
