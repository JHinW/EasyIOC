using EasyDI.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Abstractions
{
    public abstract class ResolvableTypeBase: IResolvableType
    {
        public Type OriginalType { get; }

        public Type ResolvableType { get; }

        public (int, ServiceLifetime, InstanceScopeFactory) Factories { get; }

        protected ResolvableTypeBase(
            Type originalType,
            Type resolvableType
            )
        {
            OriginalType = originalType;
            ResolvableType = resolvableType;
        }
    }
}
