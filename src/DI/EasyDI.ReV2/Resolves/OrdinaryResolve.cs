
using System;

using EasyDI.ReV2.Abstractions;

namespace EasyDI.ReV2.Resolves
{
    public class OrdinaryResolve: ResolvableBase
    {

        public OrdinaryResolve(Type type) : base(type)
        {
            base.AsEnd();
        }

    }
}
