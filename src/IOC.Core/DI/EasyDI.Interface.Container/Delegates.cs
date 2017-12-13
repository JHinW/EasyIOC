

namespace EasyDI.Definition.Container
{
    using EasyDI.Definition.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Delegates
    {
        public delegate object InstanceFactoryResolverScope(IProvider provider,  IScope scopeService);
    }
}
