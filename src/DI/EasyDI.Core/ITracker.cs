using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.Core
{
    public interface ITracker
    {
        Object Track(Type type);
    }
}
