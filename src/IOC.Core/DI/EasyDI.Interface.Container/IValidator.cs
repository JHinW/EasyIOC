

namespace EasyDI.Definition.Container
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IValidator
    {
        bool IsResolving(Type serviceType);

        void UpdateResolvingSet(Type serviceType);
    }
}
