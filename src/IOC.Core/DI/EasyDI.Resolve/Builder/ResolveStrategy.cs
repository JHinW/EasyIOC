
namespace EasyDI.Resolve.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Definition.Resolve.Abstractions;
    using EasyDI.Resolve.Statics;

    public class ResolveStrategy : ResolveStrategyBase
    {
        public ResolveStrategy(Func<IResolve, IResolvable> resolvableFactoryChain): base(resolvableFactoryChain)
        {
        }

        public override Func<Func<Type, bool>, IResolvable> CreateResovableDelegate(Type type)
        {
            return checker => {
                var resolve = ResolveHelper.ResolveBuild(type, checker);
                return CreateResolvable(resolve: resolve);
            };

        }

        protected override IResolvable CreateResolvable(IResolve resolve)
        {
            return _resolvableFactoryChain(resolve);
        }
    }
}
