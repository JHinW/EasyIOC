
using System;
using System.Collections.Generic;

using EasyDI.ReV2.Abstractions;
using EasyDI.Core;

namespace EasyDI.ReV2.Resolves
{
    public class GenericResolve: ResolvableBase
    {
        public IList<Type> DepTypes { get; }

        public GenericResolve(Type type, IList<Type> depTypes) : base(type)
        {
            base.NotAsEnd();
            DepTypes = depTypes;
        }

        public static IResolvable Create(Type type, IList<Type> depTypes)
        {
            return new GenericResolve(type, depTypes);
        }

    }
}
