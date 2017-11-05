using EasyDI.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static EasyDI.Core.Delegates;

namespace EasyDI.Re.Definitions
{
    public class CompiledTypeDef
    {
        public EasyTypeDescriptorItem EasyTypeDescriptorItem { get; set; }

        public Type RefType { get; set; }

        public InstanceFactory[] InstanceFactories { get; set; } = null;

        public Type[] DependencyType { get; set; }
    }
}
