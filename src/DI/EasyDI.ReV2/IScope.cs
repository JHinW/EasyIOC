using System;

using EasyDI.Core;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Core
{
    public interface IScope
    {
        bool IsResolving(Type baseType);

        void AddToScopeSet(Type baseType);

        InstanceScopeFactory TryGetOrAdd(IResolvable resolvableType);

        object TryAddOrUpdate(IResolvable resolvableType, int index, ServiceLifetime serviceLifetime, Func<Object> factory);
    }
}
