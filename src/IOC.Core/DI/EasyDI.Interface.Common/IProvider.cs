

namespace EasyDI.Definition.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IProvider: IServiceProvider
    {
        bool CanbeResolved(Type serviceType);
    }
}
