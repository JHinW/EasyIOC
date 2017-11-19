using EasyDI.ReV2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Definitions
{
    public class EnumrableResolvableTypeDef: ResolvableTypeBase
    {
        public IEnumerable<(int, Delgates.InstanceScopeFactory)> Factories { get; }

        public EnumrableResolvableTypeDef(
              Type originalType,
              Type resolvableType,
              IEnumerable<(int, Delgates.InstanceScopeFactory)> factories
            )
          : base(originalType,
                resolvableType
                )
        {
            Factories = factories;
        }
    }
}
