
namespace EasyDI.Interface.Resolve
{
    using System;

    public interface IResolvable
    {
        Type OriginalType { get; }

        Type IndexedType { get; }
    }
}
