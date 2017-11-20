using EasyDI.ReV2.Core;
using EasyDI.ReV2.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Implements
{
    public class ScopeService : IScope
    {
        private readonly ConcurrentDictionary<Type, IList<(int, object)>> _scopeContainer;

        private readonly HashSet<Type> _resolvingTypeSet;

        public ScopeService()
        {
            _scopeContainer = new ConcurrentDictionary<Type, IList<(int, object)>>();
            _resolvingTypeSet = new HashSet<Type>();
        }

        public void AddToScopeSet(Type baseType)
        {
            _resolvingTypeSet.Add(baseType);
        }

        public bool IsResolving(Type baseType)
        {
            return _resolvingTypeSet.Contains(baseType);
        }

        public InstanceScopeFactory TryGetOrAdd(IResolvableType resolvableType)
        {
            switch (resolvableType)
            {
                case OrdinaryResolvableTypeDef ordinaryResolvableTypeDef:

                    return (resolver, scope) =>
                    {
                        return _scopeContainer.GetOrAdd(
                          ordinaryResolvableTypeDef.ResolvableType,
                            (key) => {
                                return null;
                            });
                    };

                case EnumrableResolvableTypeDef enumrableResolvableTypeDef:

                    return null;
            }

            return null;
        }
    }
}
