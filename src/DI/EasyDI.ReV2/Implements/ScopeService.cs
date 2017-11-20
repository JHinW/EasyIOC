using EasyDI.Core;
using EasyDI.ReV2.Core;
using EasyDI.ReV2.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Implements
{
    public class ScopeService : IScope
    {
        private readonly ConcurrentDictionary<Type, IList<InstanceDescriptorDef>> _scopeContainer;

        private readonly HashSet<Type> _resolvingTypeSet;

        private readonly Func<Type, CurriedDescriptorDef, InstanceScopeFactory> _singletonGetDelegate;

        // private readonly 

        public ScopeService(Func<Type, CurriedDescriptorDef, InstanceScopeFactory> singletonGetDelegate)
        {
            _scopeContainer = new ConcurrentDictionary<Type, IList<InstanceDescriptorDef>>();
            _resolvingTypeSet = new HashSet<Type>();
            _singletonGetDelegate = singletonGetDelegate;
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
                    var factory = ordinaryResolvableTypeDef.Factory;
                    // var container = lifetime == ServiceLifetime.Scoped ? _scopeContainer

                    if (lifetime == ServiceLifetime.Scoped)
                    {
                        return ScopeGet(
                            ordinaryResolvableTypeDef.ResolvableType,
                            factory);
                    }
                    else if (lifetime == ServiceLifetime.Singleton)
                    {
                        return SingletonGet(
                            ordinaryResolvableTypeDef.ResolvableType,
                            factory);
                    }
                    else
                    {
                        return (resolver, scope) => factory.InstanceScopeFactory(resolver, scope);
                    }

                case EnumrableResolvableTypeDef enumrableResolvableTypeDef:

                    return null;
            }

            return null;
        }

        public InstanceScopeFactory ScopeGet(Type indexType, CurriedDescriptorDef curriedDescriptorDef)
        {
            var factory = curriedDescriptorDef.InstanceScopeFactory;
            var index = curriedDescriptorDef.Index;
            return (resolver, scope) =>
            {
                var result = _scopeContainer.AddOrUpdate(
                   indexType,
                     (key) =>
                     {
                         var list = new List<InstanceDescriptorDef>
                         {
                            InstanceDescriptorDef.Create(index, factory(resolver, scope))
                         };
                         return list;
                     }, (key, old) =>
                     {
                         var list = old;
                         if (!list.Any(def => def.Index == index))
                         {
                            list.Add(InstanceDescriptorDef.Create(index, factory(resolver, scope)));
                         }

                         return list;
                     });
                return result.Single(def => def.Index == index).Instance;
            };
        }

        public Delgates.InstanceScopeFactory SingletonGet(Type indexType, CurriedDescriptorDef curriedDescriptorDef)
        {
            return _singletonGetDelegate(indexType, curriedDescriptorDef);
        }


    }
}
