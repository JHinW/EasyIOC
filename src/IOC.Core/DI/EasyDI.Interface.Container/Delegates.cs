

namespace EasyDI.Definition.Container
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Common;

    public static class Delegates
    {
        public delegate object InstanceFactoryResolverScope(IProvider provider,  IScope scopeService);
    }
}
