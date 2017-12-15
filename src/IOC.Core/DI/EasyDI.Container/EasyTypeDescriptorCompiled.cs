

namespace EasyDI.Container
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public struct EasyTypeDescriptorCompiled
    {
        public IEnumerable<Type> DepTypes { get; }

        public InstanceFactoryResolvable CompiledDelegate { get; }

        public EasyTypeDescriptorCompiled(
            InstanceFactoryResolvable compiledDelegate,
            IEnumerable<Type> depTypes
            )
        {
            CompiledDelegate = compiledDelegate;
            DepTypes = depTypes;
        }

        public static EasyTypeDescriptorCompiled Create(
            InstanceFactoryResolvable CompiledDelegate,
            IEnumerable<Type> DepTypes
            )
        {
            return new EasyTypeDescriptorCompiled(CompiledDelegate, DepTypes);
        }

    }
}
