

namespace EasyDI.Resolve.Strategy
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Extensions;
    
    using EasyDI.Resolve.Resolvables;

    public class EnumrableStrategy
    {
        public Func<IResolve, IResolvable> ResolvableFactory => TryResolve;

        private static IResolvable TryResolve(IResolve resolve)
        {
            if (resolve.Depth() == 1)
            {
                if (resolve.Filter(1).Count() == 1)
                {
                    if (resolve.IsIndexed)
                    {
                        return Enumrable.Create(resolve.Type, resolve.Type);
                    }
                }
            }

            return null;
        }
    }
}
