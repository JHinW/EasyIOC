
using System;
using System.Collections.Generic;
using System.Text;

using EasyDI.Definition.Container;
using EasyDI.Definition.Resolve;
using EasyDI.Resolve.Statics;
using Xunit;
using Xunit.Abstractions;

namespace EasyDI.Test.Resolve.Resolve
{
    public class Resolve_Count_Test
    {
        ITestOutputHelper output;

        public Resolve_Count_Test(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Rrsolve_Test_Count_From_CallBack()
        {
            var dic = new Dictionary<Type, bool> {
                {  typeof(string), true },
                {  typeof(IEnumerable<>), true },
                {  typeof(int), true }
            };

            Func<Type, bool> checker = t => dic.ContainsKey(t);

            var resolves = ResolveHelper.ResolveBuild(typeof(IContainer<string, int, IContainer<string, int, string>>), checker);

            ResolveHelper.ResolveTraversal_Count(resolves, count =>
            {
                output.WriteLine($"{ count } ");
            });

            Assert.Equal(1, 1);
        }
    }
}
