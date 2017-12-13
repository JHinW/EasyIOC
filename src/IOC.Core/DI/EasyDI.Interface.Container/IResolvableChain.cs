

namespace EasyDI.Definition.Container
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IResolvableChain<TRsolvable>
    {
        TRsolvable Resolvable { get; }

        IEnumerable<IResolvableChain<TRsolvable>> Dependency { get; }
    }
}
