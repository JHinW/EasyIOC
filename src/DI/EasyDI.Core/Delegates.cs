using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.Core
{
    public static class Delegates
    {
        public delegate object ResolveDelegate(Type type);

        public delegate object InstanceFactory(IResolver tracker);

        public delegate object TypeResolverDelegate(EasyTypeDescriptor easyTypeDescriptor);

        public delegate EasyTypeDescriptorItem BaseTypeToDescriptorItemDelegate(Type baseType);

        public delegate bool ResolveCheckDelegate(Type baseType);
    }
}
