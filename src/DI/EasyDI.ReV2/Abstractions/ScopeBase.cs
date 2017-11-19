using EasyDI.ReV2.Core;
using System;
using System.Collections.Generic;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Abstractions
{
    public abstract class ScopeBase : IScope
    {
        private readonly HashSet<Type> _resolvingTypeSet;

        public void AddToScopeSet(Type baseType)
        {
            throw new NotImplementedException();
        }

        public bool IsResolving(Type baseType)
        {
            throw new NotImplementedException();
        }

        public InstanceScopeFactory TryGetOrAdd(IResolvableType resolvableType)
        {
            throw new NotImplementedException();
        }
    }
}
