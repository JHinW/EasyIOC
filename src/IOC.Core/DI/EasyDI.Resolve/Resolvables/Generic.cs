

namespace EasyDI.Resolve.Resolvables
{ 
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Resolve.Abstractions;
    using EasyDI.Definition.Resolve;

    public class Generic: ResolvableBase
    {
        public IEnumerable<Type> DepTypes { get; }

        public Generic(Type originalType, 
            Type indexedType,
            IEnumerable<Type> depTypes
            ) : base(originalType, indexedType)
        {
            DepTypes = depTypes;
        }

        public static IResolvable Create(Type originalType, Type indexedType, IList<Type> depTypes)
        {
            return new Generic(originalType, indexedType, depTypes);
        }
    }
}
