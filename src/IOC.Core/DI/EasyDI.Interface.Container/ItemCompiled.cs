

namespace EasyDI.Definition.Container
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ItemCompiled
    {
        IEnumerable<Type> DepTypes { get; }

        IEnumerable<Type> DepTypess { get; }
    }
}
