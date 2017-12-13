

namespace EasyDI.Resolve.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;

    public abstract class ResolvableBase: IResolvable
    {
        public Type OriginalType { get; }

        public Type IndexedType { get; }

        protected ResolvableBase(Type originalType, Type indexedType)
        {
            OriginalType = originalType;
            IndexedType = indexedType;
        }
    }
}
