

namespace EasyDI.Resolve.Builder
{
    using System.Linq;

    using EasyDI.Definition.Resolve;
    using EasyDI.Definition.Resolve.Abstractions;

    public class ResolveStrategyBuilder : ResolveStrategyBuilderBase
    {
        public ResolveStrategyBuilder():base()
        {
        }

        public override ResolveStrategyBase Build()
        {
            ResolvableFactory lastDelegate = resolve => null;
            ResolvableFactory composed = lastDelegate;
            foreach (var middleware in _resolvableFactoryList.Reverse())
            {
                composed = middleware(composed);
            }

            return new ResolveStrategy(resolve => composed(resolve));
        }
    }
}
