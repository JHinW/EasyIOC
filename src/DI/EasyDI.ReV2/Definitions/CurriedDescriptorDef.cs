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

        public Type RefType { get;}

        public ServiceLifetime Lifetime { get; }

        public InstanceScopeFactory InstanceScopeFactory { get; }

        public CurriedDescriptorDef(
            int index,
            Type type,
            ServiceLifetime lifetime,
            InstanceScopeFactory instanceScopeFactory
           )
        {
            index = Index;
            RefType = type;
            Lifetime = lifetime;
            InstanceScopeFactory = instanceScopeFactory;
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
