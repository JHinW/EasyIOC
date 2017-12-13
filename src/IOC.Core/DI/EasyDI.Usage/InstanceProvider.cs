

namespace EasyDI.Usage
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Common;
    using EasyDI.Definition.Resolve.Abstractions;

    public class InstanceProvider : IProvider
    { 
        private ResolveStrategyBase _resolveStrategy { get; }

        public InstanceProvider(ResolveStrategyBase resolveStrategy)
        {
            _resolveStrategy = resolveStrategy;
        }

        public bool CanbeResolved(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
