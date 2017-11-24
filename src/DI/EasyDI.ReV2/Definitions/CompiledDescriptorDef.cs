using EasyDI.Core;
using System;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Definitions
{
    public class CompiledDescriptorDef
    {
        public int Index { get; }

        public Type RefType { get; }

        public ServiceLifetime Lifetime { get; }

        public ResolvableFactory ResolvableFactory { get; }

        public CompiledDescriptorDef(
            int index,
            Type type,
            ServiceLifetime lifetime,
            ResolvableFactory resolvableFactory
           )
        {
            index = Index;
            RefType = type;
            Lifetime = lifetime;
            ResolvableFactory = resolvableFactory;
        }

        public static CompiledDescriptorDef Create(
            int index,
            Type type,
            ServiceLifetime lifetime,
            ResolvableFactory resolvableFactory)
        {
            return new CompiledDescriptorDef(
                index,
                type,
                lifetime,
                resolvableFactory);
        }
    }
}
