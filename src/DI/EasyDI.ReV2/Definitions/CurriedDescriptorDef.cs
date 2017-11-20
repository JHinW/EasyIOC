using EasyDI.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Definitions
{
    public class CurriedDescriptorDef
    {
        public int Index { get; }

        public ServiceLifetime Lifetime { get; }

        public InstanceScopeFactory InstanceScopeFactory { get; }

        public CurriedDescriptorDef(
            int index,
            ServiceLifetime lifetime,
            InstanceScopeFactory instanceScopeFactory
           )
        {
            index = Index;
            Lifetime = lifetime;
            InstanceScopeFactory = instanceScopeFactory;
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
