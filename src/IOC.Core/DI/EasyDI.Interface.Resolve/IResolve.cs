

namespace EasyDI.Interface.Resolve
{
    using System;
    using System.Collections.Generic;

    public interface IResolve
    {
        Type Type { get; }

        bool IsIndexed { get; }

        IList<IResolve> SubResolves { get; }
    }
}
