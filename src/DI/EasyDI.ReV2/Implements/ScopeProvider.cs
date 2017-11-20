using EasyDI.Core;
using EasyDI.ReV2.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Implements
{
    public class ScopeProvider: IScope
    {
        private readonly ConcurrentDictionary<Type, IList<(int, object)>> _singletonContainer;

        public ScopeProvider()
        {
            _singletonContainer = new ConcurrentDictionary<Type, IList<(int, object)>>();
        }


        public IScope CreateScopeService()
        {
            return new ScopeService();
        }

        public bool IsResolving(Type baseType)
        {
            return true;
        }

        public void AddToScopeSet(Type baseType)
        {
            return;
        }

        public Delgates.InstanceScopeFactory TryGetOrAdd(IResolvableType resolvableType)
        {
            return _singletonContainer.GetOrAdd(
                        resolvableType.ResolvableType
                        );
        }
    }
}
