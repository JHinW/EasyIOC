using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Tests.mock.Generic
{
    interface IGenericService<T>
    {
        void Get(T input);
    }
}
