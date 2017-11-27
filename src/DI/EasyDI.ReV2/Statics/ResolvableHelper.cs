using System;

using EasyDI.Core;
using EasyDI.ReV2.Resolves;
using EasyDI.ReV2.Extensions;

namespace EasyDI.ReV2.Statics
{
    public static class ResolvableHelper
    {
        public static Func<ITracker, IResolvable> CreateResolveFactory(Type type)
        {
            return tracker =>
            {
                IResolvable resolvable = OrdinaryResolve.Create(type).NotAsEnd();

                if (tracker.IsIndexed(type))
                {
                    resolvable.AsEnd();
                }
                else
                {
                    resolvable
                    .TryAddGenericDep(tracker);
                }

                return resolvable;
            };

            
        }
    }
}
