

namespace EasyDI.Definition.Resolve
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITypeFulfill
    {
        Type Fulfill(Type implType, IResolvable resolvable);
    }
}
