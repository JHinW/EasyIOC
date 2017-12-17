
namespace EasyDI.Resolve.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Extensions;
    using EasyDI.Resolve.Resolvables;

    public class OrdinaryStrategy : IStrategy
    {
        public Func<IResolve, IResolvable> ResolvableFactory => TryResolve;

        private static IResolvable TryResolve(IResolve resolve)
        {
            if(resolve.Depth() == 1)
            {
                if(resolve.Filter(1).Count()  == 1)
                {
                    if (resolve.IsIndexed)
                    {
                        return Ordinary.Create(resolve.Type, resolve.Type);
                    }
                }
            }

            return null;
        }
    }
}
