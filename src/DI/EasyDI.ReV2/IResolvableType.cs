using System;

namespace EasyDI.ReV2
{
    public interface IResolvableType
    {
        Type OriginalType { get;}

        Type ResolvableType { get; }
}
}
