using EasyDI.ReV2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Definitions
{
    public class GenericResolvableDef: ResolvableTypeBase
    {
        public IList<Type> DepTypes { get; }

        public GenericResolvableDef(Type originalType,
              Type resolvableType,
              IList<Type> depTypes
            )
          : base(originalType,
                resolvableType
                )
        {
            DepTypes = depTypes;
        }
    }
}
