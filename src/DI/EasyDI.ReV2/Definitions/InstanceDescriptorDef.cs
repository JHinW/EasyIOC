using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Definitions
{
    public class InstanceDescriptorDef
    {
        public int Index { get; }

        public object Instance { get; }

        public InstanceDescriptorDef(int index, object instance)
        {
            Index = index;
            Instance = instance;
        }

        public static InstanceDescriptorDef Create(int index, object instance)
        {
            return new InstanceDescriptorDef(index, instance);
        }
    }
}
