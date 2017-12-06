using System;

using EasyDI.ReV2.Abstractions;
using EasyDI.Core;

namespace EasyDI.ReV2.Resolves
{
    public class EnumrableResolve: ResolvableBase
    {
        public EnumrableResolve(Type type): base(type)
        {
        }

        public static IResolvable Create(Type type)
        {
            return new EnumrableResolve(type);
        }
    }
}
