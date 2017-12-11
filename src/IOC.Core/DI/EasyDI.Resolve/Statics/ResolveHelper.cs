

namespace EasyDI.Resolve.Statics
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Implements;
    using EasyDI.Resolve.Extensions;
    

    public static class ResolveHelper
    {
        public static IResolve ResolveBuild(Type type, Func<Type, bool> checker)
        {
            if (checker(type))
            {
                return ResolveImpl.Create(type, checker(type), null);
            }

            if (type.IsGenericType)
            {
                var resolves = type.GenericFlatten()
                    .Select(t => ResolveBuild(t, checker));
                return ResolveImpl.Create(type, checker(type), resolves);
            }

            return ResolveImpl.Create(type, checker(type), null);
        }
    }
}
