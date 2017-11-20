using EasyDI.ReV2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Definitions
{
    public class EnumrableResolvableTypeDef: ResolvableTypeBase
    {
        public IList<CurriedDescriptorDef> Factories { get; }

        public EnumrableResolvableTypeDef(Type originalType,
              Type resolvableType,
              IList<CurriedDescriptorDef> factories
            )
          : base(originalType,
                resolvableType
                )
        {
            Factories = factories;
        }
    }
}
