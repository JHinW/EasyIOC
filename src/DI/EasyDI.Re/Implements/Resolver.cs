using EasyDI.Re.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using static EasyDI.Core.Delegates;

namespace EasyDI.Re.Implements
{
    public class Resolver: ResolverBase
    {
        public Resolver(
            BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
            ResolveCheckDelegate resolveCheckDelegate
            ):  base(baseTypeToDescriptorItemDelegate,
                resolveCheckDelegate)
        {

        }

        public override void ResolvingTypes(HashSet<Type> resolvingTypeSet)
        {
            return;
        }
    }
}
