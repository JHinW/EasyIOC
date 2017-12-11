

namespace EasyDI.Resolve.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;

    public static class IResolveStrategyBuilderExtension
    {
        public static IResolveStrategyBuilder ConfigureMiddleware(this IResolveStrategyBuilder builder, 
            Func<IResolveStrategyBuilder, IResolveStrategyBuilder> configureDelegate)
        {
            return configureDelegate(builder);
        }
    }
}
