using EasyDI.ReV2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Definitions
{
    public class OrdinaryResolvableTypeDef : ResolvableTypeBase
    {
        public CurriedDescriptorDef CurriedDescriptorDef { get; }

        public OrdinaryResolvableTypeDef(
              Type originalType,
              Type resolvableType,
              CurriedDescriptorDef curriedDescriptorDef
            )
          : base(originalType,
                resolvableType
                )
        {
            CurriedDescriptorDef = curriedDescriptorDef;
        }
    }
}
