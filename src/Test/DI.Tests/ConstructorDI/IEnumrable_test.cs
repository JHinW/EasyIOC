using EasyDI.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DI.Tests.ConstructorDI
{
    public class IEnumrable_test : ContainerTestBase
    {
        [Fact]
        public void String_IEnumrable_test()
        {
            var discripor = EasyTypeDescriptor.Create(typeof(string), "hellow world, flag1!");

            var discripor2 = EasyTypeDescriptor.Create(typeof(string), "hellow world, flag2!");

            _container.AddDescriptor(typeof(string), discripor);
            _container.AddDescriptor(typeof(string), discripor2);

            var resolver = _container.CreateTypeResolver();

            var result = resolver.GetInstance(typeof(IEnumerable<string>));

            Assert.Equal(true, typeof(IEnumerable<string>).IsAssignableFrom(result.GetType()));
        }
    }
}
