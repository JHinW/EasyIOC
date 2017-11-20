using EasyDI.Core;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Definitions
{
    public class CompiledDescriptorDef
    {
        public int Index { get; }

        public ServiceLifetime Lifetime { get; }

        public InstanceTrackScopeFactory InstanceTrackScopeFactory { get; }

        public CompiledDescriptorDef(
            int index,
            ServiceLifetime lifetime,
            InstanceTrackScopeFactory instanceTrackScopeFactory
           )
        {
            index = Index;
            Lifetime = lifetime;
            InstanceTrackScopeFactory = instanceTrackScopeFactory;
        }

        public static CompiledDescriptorDef Create(
            int index,
            ServiceLifetime lifetime,
            InstanceTrackScopeFactory instanceTrackScopeFactory)
        {
            return new CompiledDescriptorDef(
                index,
                lifetime,
                instanceTrackScopeFactory);
        }
    }
}
