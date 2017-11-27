using EasyDI.Core;
using EasyDI.ReV2.Core;
using EasyDI.ReV2.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDI.ReV2.Implements
{
    public class ScopeProvider
    {
        private readonly ConcurrentDictionary<Type, IList<InstanceDescriptorDef>> _singletonContainer;

        public ScopeProvider()
        {
            _singletonContainer = new ConcurrentDictionary<Type, IList<InstanceDescriptorDef>>();
        }


        public IScope CreateScopeService()
        {
            return new InnerScope(
                curriedDescriptorDef => SingletonGet(curriedDescriptorDef)
                );
        }

        public Delgates.InstanceScopeFactory SingletonGet(CurriedDescriptorDef curriedDescriptorDef)
        {
            var type = curriedDescriptorDef.RefType;
            var factory = curriedDescriptorDef.InstanceScopeFactory;
            var index = curriedDescriptorDef.Index;
            return (resolver, scope) =>
            {
                var result = _singletonContainer.AddOrUpdate(
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
    }
}
