using EasyDI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.Re.Definitions
{
    public class ResolvableTypeDef
    {
        public Type OriginalType { get; set; }

        public Type ResolvableType { get; set; }

        public Boolean IsGenericType { get; set; }

        public Boolean IsEnumrableType { get; set; }

        public Type[] GenericsDependencies { get; set; }

        public EasyTypeDescriptorItem EasyTypeDescriptorItem { get; set; }
    }
}
