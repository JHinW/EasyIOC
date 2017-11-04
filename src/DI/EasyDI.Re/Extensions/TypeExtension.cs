using EasyDI.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static EasyDI.Core.Delegates;

namespace EasyDI.Re.Extensions
{
    public static class TypeExtension
    {
        public static IEnumerable<Type> ExportDependency(this Type implementedType, Func<Type, Boolean> checker)
        {
            var constructors = implementedType.GetTypeInfo()
              .DeclaredConstructors
              .Where(constructor => constructor.IsPublic)
              .ToArray();

            Array.Sort(constructors,
            (a, b) => b.GetParameters().Length.CompareTo(a.GetParameters().Length));

            ConstructorInfo bestConstructor = null;
            foreach (var constructor in constructors)
            {
                bestConstructor = constructor;
                var paras = constructor.GetParameters();
                var resolveFilter = paras.Where(p => checker(p.ParameterType));
                if (paras.Length == resolveFilter.Count())
                {
                    break;
                }
                else
                {
                    throw new InvalidOperationException("Error: Invalid dependency type.");
                }
            }

            if (bestConstructor == null)
            {
                throw new InvalidOperationException("Error: No appropriate constructor.");
            }

            return bestConstructor.GetParameters().Select(p => p.ParameterType);
        }
    }
}
