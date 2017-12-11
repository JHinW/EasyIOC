
namespace EasyDI.Definition.Resolve.Abstractions
{
    using System;

    using ResolvableDelegate = System.Func<System.Func<System.Type, bool>, IResolvable>;

    public abstract class ResolveStrategyBase
    {
        protected readonly Func<IResolve, IResolvable> _resolvableFactoryChain;

        protected abstract IResolvable CreateResolvable(IResolve resolve);

        public abstract ResolvableDelegate CreateResovableDelegate(Type type);

        protected ResolveStrategyBase(Func<IResolve, IResolvable> resolvableFactoryChain)
        {
            _resolvableFactoryChain = resolvableFactoryChain;
        }
    }
}
