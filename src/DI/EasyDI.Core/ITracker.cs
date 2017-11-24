using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.Core
{
    public interface ITracker
    {
        T Track<T>(Type type);

        bool CanBeResolved(Type baseType);

        EasyTypeDescriptorItem DescriptorResolve(Type baseType);
    }
}
