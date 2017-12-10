
namespace EasyDI.Resolve.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Definition.Resolve.Abstractions;

    public class ResolveStrategy : ResolveStrategyBase
    {
        public override Func<Func<Type, bool>, IResolvable> CreateResovableDelegate(IResolve resolve)
        {
            return checker => CreateResolvable(resolve);

        }

        protected override IResolvable CreateResolvable(IResolve resolve)
        {
            throw new NotImplementedException();
        }
    }
}
