

namespace EasyDI.Definition.Resolve
{
    using System;
    using System.Collections.Generic;

    public interface IResolve
    {
        Type Type { get; }

        bool IsIndexed { get; }

        IEnumerable<IResolve> SubResolves { get; }
    }
}
