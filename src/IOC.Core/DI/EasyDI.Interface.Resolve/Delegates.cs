

namespace EasyDI.Interface.Resolve
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public delegate IResolvable ResolvableFactory(IResolve resolve);

    public delegate ResolvableFactory ResolvableMiddleware(ResolvableFactory fatory);
}
