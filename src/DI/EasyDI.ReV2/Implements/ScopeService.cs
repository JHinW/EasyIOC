using EasyDI.Core;
using EasyDI.ReV2.Core;
using EasyDI.ReV2.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Implements
{
    public class ScopeService : IScope
    {
        private readonly ConcurrentDictionary<Type, IList<InstanceDescriptorDef>> _scopeContainer;

        private readonly HashSet<Type> _resolvingTypeSet;

        private readonly Func<CurriedDescriptorDef, InstanceScopeFactory> _singletonGetDelegate;

        // private readonly 

        public ScopeService(Func<CurriedDescriptorDef, InstanceScopeFactory> singletonGetDelegate)
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

                    return GetInstanceFactory(ordinaryResolvableTypeDef.CurriedDescriptorDef);

                case EnumrableResolvableTypeDef enumrableResolvableTypeDef:

                    return GetInstanceFactory(enumrableResolvableTypeDef.CurriedDescriptorDefList);
            }

            return null;
        }

        public InstanceScopeFactory ScopeGet(CurriedDescriptorDef curriedDescriptorDef)
        {
            var type = curriedDescriptorDef.RefType;
            var factory = curriedDescriptorDef.InstanceScopeFactory;
            var index = curriedDescriptorDef.Index;
            return (resolver, scope) =>
            {
                var result = _scopeContainer.AddOrUpdate(
                   type,
                     (key) =>
                     {
                         var list = new List<InstanceDescriptorDef>
                         {
                            InstanceDescriptorDef.Create(index, type, factory(resolver, scope))
                         };
                         return list;
                     }, (key, old) =>
                     {
                         var list = old;
                         if (!list.Any(def => def.Index == index))
                         {
                            list.Add(InstanceDescriptorDef.Create(index, type, factory(resolver, scope)));
                         }

                         return list;
                     });
                return result.Single(def => def.Index == index).Instance;
            };
        }

        public InstanceScopeFactory SingletonGet(CurriedDescriptorDef curriedDescriptorDef)
        {
            return _singletonGetDelegate(curriedDescriptorDef);
        }

        public InstanceScopeFactory GetInstanceFactory(CurriedDescriptorDef curriedDescriptorDef)
        {
            var lifetime = curriedDescriptorDef.Lifetime;

            if (lifetime == ServiceLifetime.Scoped)
            {
                return ScopeGet(curriedDescriptorDef);
            }
            else if (lifetime == ServiceLifetime.Singleton)
            {
                return SingletonGet(curriedDescriptorDef);
            }
            else
            {
                return (resolver, scope) => curriedDescriptorDef.InstanceScopeFactory(resolver, scope);
            }
        }

        public InstanceScopeFactory GetInstanceFactory(IList<CurriedDescriptorDef> curriedDescriptorDefList)
        {
            var type = curriedDescriptorDefList[0].RefType;
            return (resolver, scope) =>
            {
                Type dictType = typeof(List<>).MakeGenericType(type);
                var lst = Activator.CreateInstance(dictType);
                MethodInfo info = typeof(List<>).MakeGenericType(type).GetMethod("Add");
                foreach (var def in curriedDescriptorDefList)
                {
                    info.Invoke(lst, new[] { GetInstanceFactory(def) });
                }
                return lst;
            };
        }

        public object TryAddOrUpdate(IResolvableType resolvableType, int index, ServiceLifetime serviceLifetime, Func<object> factory)
        {
            throw new NotImplementedException();
        }
    }
}
