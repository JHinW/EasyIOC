

namespace EasyDI.Resolve.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;

    public static class IResolveStrategyBuilderExtension
    {
        public static IResolveStrategyBuilder ConfigureMiddleware(
            this IResolveStrategyBuilder builder, 
            Func<IResolveStrategyBuilder, IResolveStrategyBuilder> configureDelegate)
        {
            return configureDelegate(builder);
        }

        public static IResolveStrategyBuilder AddStragtegy(
            this IResolveStrategyBuilder builder,
            Type type)
        {
            if (type.IsAssignableFrom(typeof(IStrategy)))
            {
                var stragtegy = Activator.CreateInstance(type) as IStrategy;

                builder.AddStrategyMiddleware(next => resolve => stragtegy.ResolvableFactory(resolve));
            }

            return builder;
        }

        public static IResolveStrategyBuilder AddStragtegy<T>(this IResolveStrategyBuilder builder) where T : IStrategy
        {
            return builder.AddStragtegy(typeof(T));
        }
    }
}
