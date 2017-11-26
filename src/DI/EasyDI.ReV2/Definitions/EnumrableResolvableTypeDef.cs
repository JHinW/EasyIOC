using EasyDI.ReV2.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Definitions
{
    public class EnumrableResolvableTypeDef: ResolvableTypeBase
    {
        public IList<CurriedDescriptorDef> CurriedDescriptorDefList { get; }

        public Boolean IsGenericEnumrable { get; }

        public Boolean GenericEnumrable { get; }

        public EnumrableResolvableTypeDef(Type originalType,
              Type resolvableType,
              IList<CurriedDescriptorDef> curriedDescriptorDefList
            )
          : base(originalType,
                resolvableType
                )
        {
            CurriedDescriptorDefList = curriedDescriptorDefList;
        }
    }
}
