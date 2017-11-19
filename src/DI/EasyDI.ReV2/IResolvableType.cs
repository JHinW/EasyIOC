using EasyDI.Core;
using System;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2
{
    public interface IResolvableType
    {
        Type OriginalType { get;}

        Type ResolvableType { get; }

        (int, ServiceLifetime, InstanceScopeFactory)  Factories { get; }
}
}
