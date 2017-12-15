

namespace EasyDI.Resolve.Abstractions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Resolve;
    using EasyDI.Resolve.Resolvables;
    

    public abstract class TypeFulfillBase : ITypeFulfill
    {
        protected TypeFulfillBase()
        {
        }

        public Type Fulfill(Type implType, IResolvable resolvable)
        {
            switch(resolvable)
            {
                case Enumrable enumrable:

                    return implType;

                case Generic generic:

                    implType = implType.MakeGenericType(generic.DepTypes.ToArray());
                    return implType;

                case Ordinary ordinary:

                    return implType;
            }

            return null;
        }
    }
}
