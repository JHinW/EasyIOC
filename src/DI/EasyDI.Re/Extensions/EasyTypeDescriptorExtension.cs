using EasyDI.Core;
using EasyDI.Re.Statics;
using System;
using System.Linq;
using static EasyDI.Core.Delegates;

namespace EasyDI.Re.Extensions
{
    public static class EasyTypeDescriptorExtension
    {
        public static InstanceFactory AsInstanceFactory(this EasyTypeDescriptor item)
        {
            var selectedItem = item;
            return resolver =>
            {
                if (selectedItem.ImplementationFactory != null)
                {
                    return selectedItem.ImplementationFactory(resolver);
                }

                if (selectedItem.ImplementationInstance != null)
                {
                    return selectedItem.ImplementationInstance;
                }

                if (selectedItem.ImplementationType != null)
                {
                    var implT = selectedItem.ImplementationType;
                    var paras = implT.ExportDependency(type => resolver.CanBeResolved(type))
                     .Select(type => TypeHelper.BaseType2InstanceFactory(type, resolver))
                     .Select(factory => factory(resolver));

                    return Activator.CreateInstance(implT, paras);
                }

                return null;
            };
        }
    }
}
