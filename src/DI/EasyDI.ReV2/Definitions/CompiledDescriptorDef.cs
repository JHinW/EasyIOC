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

        public InstanceTrackScopeFactory InstanceTrackScopeFactory { get; }

        public CompiledDescriptorDef(
            int index,
            Type type,
            ServiceLifetime lifetime,
            InstanceTrackScopeFactory instanceTrackScopeFactory
           )
        {
            index = Index;
            RefType = type;
            Lifetime = lifetime;
            InstanceTrackScopeFactory = instanceTrackScopeFactory;
        }

        public static CompiledDescriptorDef Create(
            int index,
            Type type,
            ServiceLifetime lifetime,
            InstanceTrackScopeFactory instanceTrackScopeFactory)
        {
            return new CompiledDescriptorDef(
                index,
                type,
                lifetime,
                instanceTrackScopeFactory);
        }
    }
}
