

namespace EasyDI.Interface.Resolve.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class ResolveStrategyBuilderBase: IResolveStrategyBuilder
    {
        private readonly IList<ResolvableMiddleware> _resolvableFactoryList;

        public abstract ResolveStrategyBase Build();
    }
}
