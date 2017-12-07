

namespace EasyDI.Interface.Resolve.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class ResolveStrategyBase
    {
        private readonly Func<IResolve, IResolvable> _resolvableFactoryChain;

        public abstract IResolvable CreateResolvable(IResolve resolve);
    }
}
