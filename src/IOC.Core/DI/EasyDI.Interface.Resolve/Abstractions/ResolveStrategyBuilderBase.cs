

namespace EasyDI.Definition.Resolve.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class ResolveStrategyBuilderBase: IResolveStrategyBuilder
    {
        protected readonly IList<ResolvableMiddleware> _resolvableFactoryList;

        protected ResolveStrategyBuilderBase()
        {
            _resolvableFactoryList = new List<ResolvableMiddleware>();
        }

        public void AddStrategyMiddleware(ResolvableMiddleware middleware)
        {
            _resolvableFactoryList.Add(middleware);
        }

        public abstract ResolveStrategyBase Build();
    }
}
