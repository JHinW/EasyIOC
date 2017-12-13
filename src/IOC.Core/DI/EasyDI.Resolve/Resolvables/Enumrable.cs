

namespace EasyDI.Resolve.Resolvables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Resolve.Abstractions;
    using EasyDI.Definition.Resolve;

    public class Enumrable: ResolvableBase
    {
        public Enumrable(Type originalType, Type indexedType): base(originalType, indexedType)
        {
        }

        public static IResolvable Create(Type originalType, Type indexedType)
        {
            return new Ordinary(originalType, indexedType);
        }
    }
}
