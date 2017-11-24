using EasyDI.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Core
{
    public interface IScope
    {
        bool IsResolving(Type baseType);

        void AddToScopeSet(Type baseType);

        InstanceScopeFactory TryGetOrAdd(IResolvableType resolvableType);

        object TryAddOrUpdate(IResolvableType resolvableType, int index, ServiceLifetime serviceLifetime, Func<Object> factory);
    }
}
