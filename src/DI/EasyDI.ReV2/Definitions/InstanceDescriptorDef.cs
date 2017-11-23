using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2.Definitions
{
    public class InstanceDescriptorDef
    {
        public int Index { get; }

        public Type RefType { get; }

        public object Instance { get; }

        public InstanceDescriptorDef(int index, Type type, object instance)
        {
            Index = index;
            RefType = type;
            Instance = instance;
        }

        public static InstanceDescriptorDef Create(int index, Type type, object instance)
        {
            return new InstanceDescriptorDef(index, type, instance);
        }
    }
}
