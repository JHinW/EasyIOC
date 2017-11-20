using EasyDI.ReV2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Definitions
{
    public class OrdinaryResolvableTypeDef : ResolvableTypeBase
    {
        public CurriedDescriptorDef Factory{ get; }

        public OrdinaryResolvableTypeDef(
              Type originalType,
              Type resolvableType,
              CurriedDescriptorDef factory
            )
          : base(originalType,
                resolvableType
                )
        {
            Factory = factory;
        }
    }
}
