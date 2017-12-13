

namespace EasyDI.Resolve.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Statics;

    public static class IResolveExtension
    {
        public static int Depth(this IResolve resolve)
        {
            return ResolveHelper.ResolveTraversal_Depth(resolve);
        }

        public static IEnumerable<IResolve> Filter(this IResolve resolve, int level)
        {
            return ResolveHelper.ResolveTraversal_Level(resolve, level);
        }
    }
}
