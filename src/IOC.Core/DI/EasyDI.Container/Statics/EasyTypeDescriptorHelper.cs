

namespace EasyDI.Container.Statics
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Common;
    using EasyDI.Definition.Container;
    using EasyDI.Definition.Resolve;
    using static EasyDI.Definition.Container.Delegates;
    using EasyDI.Container.Extensions;

    public static class EasyTypeDescriptorHelper
    {
        public static EasyTypeDescriptorCompiled EasyTypeDescriptorCompile(
            EasyTypeDescriptor disp,
            int index,
            ITypeFulfill concreter
            )
        {



            InstanceFactoryResolvable factory = resolvable => instanceFactoryResolverScope => (provider, scope) =>
            {
                return Manufacture(disp, 
                    index, 
                    concreter, 
                    resolvable, 
                    instanceFactoryResolverScope, 
                    provider, 
                    scope);
            };



            return EasyTypeDescriptorCompiled.Create(factory, null);
        }


        public static object Manufacture(
            EasyTypeDescriptor item,
            int index,
            ITypeFulfill concreter,
            IResolvable resolvable, 
            InstanceFactoryResolverScope instanceFactoryResolverScope,
            IProvider provider,
            IScope scope
            )
        {
            var selectedItem = item;
            var type = item.ServiceType;

            object ret = null;

            if (selectedItem.ImplementationFactory != null)
            {
                ret = scope.TryAddOrUpdate(type,
                   index,
                   item.Lifetime,
                   () => selectedItem.ImplementationFactory(provider));
            }

            if (selectedItem.ImplementationInstance != null)
            {
                ret = scope.TryAddOrUpdate(type,
                   index,
                   item.Lifetime,
                   () => selectedItem.ImplementationInstance);
            }


            if (selectedItem.ImplementationType != null)
            {
                ret = scope.TryAddOrUpdate(type,
                   index,
                   item.Lifetime,
                   () =>
                   {
                       var implT = selectedItem.ImplementationType;

                       implT = concreter.Fulfill(implT, resolvable);

                       var paras = implT
                           .ExportConstructorParams(t => provider.CanbeResolved(t))
                           .Select(t => instanceFactoryResolverScope(provider, scope))
                           .ToArray();

                       return Activator.CreateInstance(implT, paras);

                   });
            }

            return null;
        }
    }
}
