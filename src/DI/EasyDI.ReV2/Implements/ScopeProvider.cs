using EasyDI.Core;
using EasyDI.ReV2.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Implements
{
    public class ScopeProvider
    {
        private readonly ConcurrentDictionary<Type, object> _singletonContainer;

        public ScopeProvider()
        {
            _singletonContainer = new ConcurrentDictionary<Type, object>();
        }

        public object TryGetOrAdd(IResolvableType resolvableType, Func<object> factory)
        {
            return _singletonContainer.GetOrAdd(
                        resolvableType.ResolvableType,
                        factory()
                        );
        }

        public IScope CreateScopeService()
        {
            return new ScopeService();
        }

    }
}
