

namespace EasyDI.Resolve.Usages
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Extensions;
    using EasyDI.Resolve.Resolvables;
    using EasyDI.Resolve.Strategy;

    public static class IResolveStrategyBuilderExtension
    {
        public static IResolveStrategyBuilder AddInternalStrategy(this IResolveStrategyBuilder builder)
        {
            builder.AddStragtegy<OrdinaryStrategy>();
            builder.AddStragtegy<EnumrableStrategy>();
            builder.AddStragtegy<GenericStragtegy>();
            return builder;
        }
    }
}
