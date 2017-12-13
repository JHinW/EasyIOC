

namespace EasyDI.Resolve.Resolvables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Abstractions;

    public class Ordinary : ResolvableBase
    {
        public Ordinary(Type originalType, Type indexedType): base(originalType, indexedType)
        {
        }

        public static IResolvable Create(Type originalType, Type indexedType)
        {
            return new Ordinary(originalType, indexedType);
        }
    }
}