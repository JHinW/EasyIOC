using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.Core
{
    public interface IResolver
    {
        Object GetInstance(Type baseType);

        bool CanBeResolved(Type baseType);

        EasyTypeDescriptorItem DecriptorResolve(Type baseType);

        void ResolvingTypes(HashSet<Type> resolvingTypeSet);

        bool IsResolving(Type baseType);

        void AddToScopeSet(Type baseType);
    }
}
