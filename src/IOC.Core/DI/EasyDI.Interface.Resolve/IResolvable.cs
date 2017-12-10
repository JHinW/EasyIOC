
namespace EasyDI.Definition.Resolve
{
    using System;

    public interface IResolvable
    {
        Type OriginalType { get; }

        Type IndexedType { get; }
    }
}
