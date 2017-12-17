

namespace EasyDI.Container.Validator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Container;
    using EasyDI.Definition.Resolve;

    public class ResolvableChain : IResolvableChain<IResolvable>
    {
        public IResolvable Resolvable { get; }

        public IEnumerable<IResolvableChain<IResolvable>> Dependency { get; }
    }
}
