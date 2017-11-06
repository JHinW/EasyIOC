using DI.Tests.mock.Generic;
using EasyDI.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DI.Tests.ConstructorDI
{
    public class Generic_Test: ContainerTestBase
    {
        [Fact]
        public void Resolve_SimpleGeneric()
        {
            var discripor = EasyTypeDescriptor.Create(typeof(string), "hellow world, flag1!");

            var discripor2 = EasyTypeDescriptor.Create(typeof(IGenericService<>), typeof(GenericService<>));

            _container.AddDescriptor(typeof(string), discripor);
            _container.AddDescriptor(typeof(IGenericService<>), discripor2);

            var resolver = _container.CreateTypeResolver();

            var result = resolver.GetInstance(typeof(IGenericService<string>));

            Assert.Equal(true, typeof(IGenericService<string>).IsAssignableFrom(result.GetType()));
        }

    }
}
