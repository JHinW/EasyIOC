
namespace EasyDI.Interface.Resolve.Abstractions
{
    using System;

    using ResolvableDelegate = System.Func<System.Func<System.Type, bool>, IResolvable>;

    public abstract class ResolveStrategyBase
    {
        private readonly Func<IResolve, IResolvable> _resolvableFactoryChain;

        protected abstract IResolvable CreateResolvable(IResolve resolve);

        public abstract ResolvableDelegate CreateResovableDelegate(IResolve resolve);
    }
}
