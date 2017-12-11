
namespace EasyDI.Resolve.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;

    public class ResolveImpl : IResolve
    {
        public Type Type { get; }

        public bool IsIndexed { get; }

        public IEnumerable<IResolve> SubResolves { get; }

        public ResolveImpl(Type type, bool isIndexed)
        {
            Type = type;
            IsIndexed = isIndexed;
        }

        public ResolveImpl(Type type,
            bool isIndexed,
             IEnumerable<IResolve> subResolves
            ): this(type, isIndexed)
        {
            SubResolves = subResolves;

        }

        public static IResolve Create(Type type,
            bool isIndexed,
            IEnumerable<IResolve> subResolves
            )
        {
            return new ResolveImpl(type, isIndexed, subResolves);
        }


    }
}
