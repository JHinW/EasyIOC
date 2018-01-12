

namespace EasyDI.Resolve.Statics
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Implements;
    using EasyDI.Resolve.Extensions;
    
    public static class ResolveHelper
    {
        public static IResolve ResolveBuild(Type type, Func<Type, bool> checker)
        {
            /*
            if (checker(type))
            {
                return ResolveImpl.Create(type, checker(type), null);
            }
            */

            if (type.IsGenericType && type.IsConstructedGenericType)
            {
                var resolves = type.GenericFlatten()
                    .Select(t => ResolveBuild(t, checker));
                return ResolveImpl.Create(type, checker(type), resolves);
            }

            return ResolveImpl.Create(type, checker(type), null);
        }

        internal static void ResolveTraversal_Preorder(IResolve resolve, Action<IResolve, int> action, int level)
        {
            action(resolve, level);

            if (resolve.SubResolves == null) return;

            foreach (var child in resolve.SubResolves)
            {
                ResolveTraversal_Preorder(child, action, level + 1);
            }
        }

        public static void ResolveTraversal_Preorder(IResolve resolve, Action<IResolve, int> action)
        {
            var level = 1;
            action(resolve, level);

            if (resolve.SubResolves == null) return;

            foreach (var child in resolve.SubResolves)
            {
                ResolveTraversal_Preorder(child, action, level + 1);
            }
        }

        public static int ResolveTraversal_Depth(IResolve resolve)
        {
            if (resolve == null) return 0;

            if (resolve.SubResolves == null) return 1;

            return resolve.SubResolves.Max(re => ResolveTraversal_Depth(re)) + 1;
        }

        internal static IEnumerable<IResolve> ResolveTraversal_Level(IResolve resolve, int levelTag, int destinationLevel)
        {
            if (levelTag == destinationLevel)
                return Enumerable.Empty<IResolve>().Append(ResolveImpl.Create(resolve.Type, resolve.IsIndexed, null));

            if (resolve.SubResolves == null)
                return Enumerable.Empty<IResolve>();

            return resolve.SubResolves.Aggregate(Enumerable.Empty<IResolve>(), (acc, ele) =>
            {
                return acc.Concat(ResolveTraversal_Level(ele, levelTag + 1, destinationLevel));
            });
        }

        public static IEnumerable<IResolve> ResolveTraversal_Level(IResolve resolve, int destinationLevel)
        {
            if (ResolveTraversal_Depth(resolve) < destinationLevel)
                throw new InvalidOperationException("Can not get the specific level data.");

            return ResolveTraversal_Level(resolve, 1, destinationLevel);
        }

        public static int ResolveTraversal_Count(IResolve resolve)
        {
            if (resolve == null) return 0;

            if (resolve.SubResolves == null) return 1;

            return resolve.SubResolves.Sum(re => ResolveTraversal_Count(re)) + 1;
        }


        public static void ResolveTraversal_Count(IResolve resolve, Action<int> action)
        {
            if (resolve == null)
            {
                action(0);
                return;
            }
            

            if (resolve.SubResolves == null)
            {
                action(1);
                return;
            }
            

            // Action<int> lastAction = action;

            var lastAction = resolve.SubResolves.Aggregate(action, (acc, ele) =>
            {
                return result =>
                {
                    ResolveTraversal_Count(ele, r => acc(result + r));

                };
            });

            //foreach (var re in resolve.SubResolves)
            //{
            //    var temp = re;
            //    lastAction = result =>
            //    {
            //        ResolveTraversal_Count(temp, r => lastAction(result + r));

            //    };
            //}

            lastAction(1);

        }
    }
}
