
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

using EasyDI.Definition.Container;
using EasyDI.Definition.Resolve;
using EasyDI.Resolve.Statics;
using Xunit.Abstractions;
using System.Linq;

namespace EasyDI.Test.Resolve.Resolve
{
    public class Resolve_Traversal_Test
    {

        ITestOutputHelper output;

        public Resolve_Traversal_Test(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Resolve_Test()
        {
            var dic = new Dictionary<Type, bool> {
                {  typeof(string), true },
                {  typeof(IEnumerable<>), true },
                {  typeof(int), true }
            };

            Func<Type, bool> checker = t => dic.ContainsKey(t);

            Action<IResolve, int> action = (res, level) =>
            {
                output.WriteLine($"level ${level} ");
            };

            var resolves = ResolveHelper.ResolveBuild(typeof(IContainer<string, int, IContainer<string, int, string>>), checker);

            ResolveHelper.ResolveTraversal_Preorder(resolves, action);

            Assert.Equal(1, 1);
        }


        [Fact]
        public void Resolve_Test_Count()
        {
            var dic = new Dictionary<Type, bool> {
                {  typeof(string), true },
                {  typeof(IEnumerable<>), true },
                {  typeof(int), true }
            };

            Func<Type, bool> checker = t => dic.ContainsKey(t);

            Action<IResolve, int> action = (res, level) =>
            {
                output.WriteLine($"level ${level} ");
            };

            var resolves = ResolveHelper.ResolveBuild(typeof(IContainer<string, int, IContainer<string, int, string>>), checker);

            var depth = ResolveHelper.ResolveTraversal_Depth(resolves);

            Assert.Equal(3, depth);
        }


        [Fact]
        public void Resolve_Test_Level()
        {
            var dic = new Dictionary<Type, bool> {
                {  typeof(string), true },
                {  typeof(IEnumerable<>), true },
                {  typeof(int), true }
            };

            Func<Type, bool> checker = t => dic.ContainsKey(t);

            Action<IResolve, int> action = (res, level) =>
            {
                output.WriteLine($"level ${level} ");
            };

            var resolves = ResolveHelper.ResolveBuild(typeof(IContainer<string, int, IContainer<string, int, string>>), checker);

            var ret = ResolveHelper.ResolveTraversal_Level(resolves, 2);

            Assert.Equal(4, ret.Count());
        }

        [Fact]
        public void Resolve_Test_Level_3()
        {
            var dic = new Dictionary<Type, bool> {
                {  typeof(string), true },
                {  typeof(IEnumerable<>), true },
                {  typeof(int), true }
            };

            Func<Type, bool> checker = t => dic.ContainsKey(t);

            Action<IResolve, int> action = (res, level) =>
            {
                output.WriteLine($"level ${level} ");
            };

            var resolves = ResolveHelper.ResolveBuild(typeof(IContainer<string, int, IContainer<string, int, string>>), checker);

            var ret = ResolveHelper.ResolveTraversal_Level(resolves, 3);

            Assert.Equal(4, ret.Count());
        }
    }
}
