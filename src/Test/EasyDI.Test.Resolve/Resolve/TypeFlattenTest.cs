
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using EasyDI.Resolve.Statics;
using EasyDI.Definition.Resolve;
using EasyDI.Definition.Container;

namespace EasyDI.Test.Resolve.Resolve
{
    public class TypeFlattenTest
    {
        [Fact]
        public void Resolve_Test()
        {
            Func<Type, bool> checker = t => true;

            var resolves = ResolveHelper.ResolveBuild(typeof(string), checker);

            Assert.Equal(true, typeof(IResolve).IsAssignableFrom(resolves.GetType()));
        }


        [Fact]
        public void Resolve_Test_Generic_With2Params()
        {
            var dic = new Dictionary<Type, bool> {
                {  typeof(string), true },
                {  typeof(IEnumerable<>), true },
                {  typeof(int), true }
            };

            Func<Type, bool> checker = t => dic.ContainsKey(t);

            var resolves = ResolveHelper.ResolveBuild(typeof(IEnumerable<string>), checker);

            Assert.Equal(typeof(IResolve).IsAssignableFrom(resolves.GetType()), true);
        }


        [Fact]
        public void Resolve_Test_Generic_With3Params()
        {
            var dic = new Dictionary<Type, bool> {
                {  typeof(string), true },
                {  typeof(IEnumerable<>), true },
                {  typeof(int), true }
            };

            Func<Type, bool> checker = t => dic.ContainsKey(t);

            var resolves = ResolveHelper.ResolveBuild(typeof(IContainer<string, int, string>), checker);

            Assert.Equal(true, typeof(IResolve).IsAssignableFrom(resolves.GetType()));
        }
    }
}
