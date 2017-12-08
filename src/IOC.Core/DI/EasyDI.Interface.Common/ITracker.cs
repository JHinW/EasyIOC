
namespace EasyDI.Interface.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITracker
    {
        T Track<T>(Type type);

        bool IsIndexed(Type type);

        T ContainerResolve<T>(Type serviceType);
    }
}
