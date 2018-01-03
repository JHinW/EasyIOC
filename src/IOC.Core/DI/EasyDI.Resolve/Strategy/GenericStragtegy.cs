

namespace EasyDI.Resolve.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Extensions;
    using EasyDI.Resolve.Resolvables;

    public class GenericStragtegy : IStrategy
    {
        public Func<IResolve, IResolvable> ResolvableFactory => TryResolve;

        private static IResolvable TryResolve(IResolve resolve)
        {
            if (resolve.Depth() == 2)
            {
                if (resolve.Filter(1).Count() == 1)
                {
                    var level2 = resolve.Filter(2);

                    if (level2.ToArray()[0].IsIndexed)
                    {
                        return Generic.Create(
                            resolve.Type,
                            level2.ToArray()[0].Type,
                            level2.TakeWhile((ele, index) => index > 1).Select(e => e.Type)
                            );
                    }
                }
            }

            return null;
        }
    }
}
