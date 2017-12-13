

namespace EasyDI.Definition.Container
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Common;

    public interface IScope
    {
        object TryAddOrUpdate(Type type,
            int index,
            ServiceLifetime serviceLifetime,
            Func<Object> factory);
    }
}
