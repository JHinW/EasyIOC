
namespace EasyDI.Definition.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITracker<TDispItem, TCompiledItem>
    {
        TCompiledItem Track(Type type);

        bool IsIndexed(Type type);

        TDispItem ContainerResolve(Type serviceType);
    }
}
