using System;

using EasyDI.Core;
using System.Collections.Generic;
using EasyDI.ReV2.Resolves;
using System.Collections;

namespace EasyDI.ReV2.Extensions
{
    public static class ResolvableExtension
    {
        public static IResolvable TryAddGenericDep(this IResolvable resolvable, ITracker tracker)
        {
            var type = resolvable.Type;

            var genericType = type.GetGenericTypeDefinition();

            var deps = type.GetGenericArguments();

            if (tracker.IsIndexed(genericType))
            {
                resolvable.SetDep(GenericResolve.Create(genericType, deps).AsEnd());
            }
            else
            {
                resolvable.TryAddEnumrableDep(tracker);
            }

            return resolvable;
        }

        private static IResolvable TryAddEnumrableDep(this IResolvable resolvable, ITracker tracker)
        {
            var type = resolvable.Type;
            var genericType = type.GetGenericTypeDefinition();
            var deps = type.GetGenericArguments();

            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                if(deps.Length == 1)
                {
                    if (tracker.IsIndexed(deps[0]))
                    {
                        resolvable.SetDep(EnumrableResolve.Create(deps[0]).AsEnd());
                    }
                }
            }

            return resolvable;
        }
    }
}
