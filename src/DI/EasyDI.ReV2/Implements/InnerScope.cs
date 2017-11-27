using EasyDI.Core;
using EasyDI.ReV2.Core;
using EasyDI.ReV2.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Implements
{
    public class InnerScope : IScope
    {

        private readonly ConcurrentDictionary<Type, IList<InstanceDescriptorDef>> _scopeContainer;

        private readonly HashSet<Type> _resolvingTypeSet;

        private readonly Func<CurriedDescriptorDef, InstanceScopeFactory> _singletonGetDelegate;

        // private readonly 

        public InnerScope(Func<CurriedDescriptorDef, InstanceScopeFactory> singletonGetDelegate)
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

        public InstanceScopeFactory TryGetOrAdd(IResolvable resolvableType)
        {
            throw new NotImplementedException();
        }

        public object TryAddOrUpdate(IResolvable resolvableType, int index, ServiceLifetime serviceLifetime, Func<Object> factory)
        {
            var lifetime = serviceLifetime;

            if (lifetime == ServiceLifetime.Scoped)
            {
                return ScopeGet(resolvableType.Type,
                    index,
                    factory);
            }
            else if (lifetime == ServiceLifetime.Singleton)
            {
                return SingletonGet(resolvableType.Type,
                    index,
                    factory);
            }
            else
            {
                return factory;
            }
        }


        public object ScopeGet(Type type, int index, Func<Object> factory)
        {
            var result = _scopeContainer.AddOrUpdate(
                   type,
                     (key) =>
                     {
                         var list = new List<InstanceDescriptorDef>
                         {
                            InstanceDescriptorDef.Create(index, type, factory())
                         };
                         return list;
                     }, (key, old) =>
                     {
                         var list = old;
                         if (!list.Any(def => def.Index == index))
                         {
                             list.Add(InstanceDescriptorDef.Create(index, type, factory()));
                         }

                         return list;
                     });
            return result.Single(def => def.Index == index).Instance;
        }

        public object SingletonGet(Type type, int index, Func<Object> factory)
        {
            return _singletonGetDelegate(null);
        }
    }
}
