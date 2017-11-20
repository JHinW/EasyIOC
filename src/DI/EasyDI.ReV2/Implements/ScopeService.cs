using EasyDI.Core;
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

        // private readonly 

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
                    var lifetime = ordinaryResolvableTypeDef.Factory.Lifetime;
                    var factory = ordinaryResolvableTypeDef.Factory.InstanceScopeFactory;
                    var index = ordinaryResolvableTypeDef.Factory.Index;
                    // var container = lifetime == ServiceLifetime.Scoped ? _scopeContainer

                    return (resolver, scope) =>
                    {
                        var result =  _scopeContainer.AddOrUpdate(
                          ordinaryResolvableTypeDef.ResolvableType,
                            (key) =>
                            {
                                var list = new List<(int, object)>();
                                list.Add((index, factory(resolver, scope)));
                                return list;
                            }, (key, old) =>
                            {
                                return null;
                            } );

                        return result[0].Item2;
                    };

                case EnumrableResolvableTypeDef enumrableResolvableTypeDef:

                    return null;
            }

            return null;
        }
    }
}
