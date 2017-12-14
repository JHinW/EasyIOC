

namespace EasyDI.Container
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public struct EasyTypeDescriptorCompiled
    {
        public IEnumerable<Type> DepTypes { get; }

        public InstanceFactoryResolvable CompiledDelegate { get; }
    }
}
