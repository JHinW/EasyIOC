using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Tests.mock.Generic
{
    public class GenericService<T> : IGenericService<T>
    {
        public string ID = "ssssssssss";

        public void Get(T input)
        {
            return;
        }
    }
}
