using EasyDI.Re.Implements;
using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Tests
{
    public class ContainerTestBase
    {
        protected EasyTypeContainer _container;

        public ContainerTestBase()
        {
            _container = new EasyTypeContainer();
        }
    }
}
