using EasyDI.Core;
using System;
using System.Linq;
using static EasyDI.Re.ReDelgates;

namespace EasyDI.Re.Extensions
{
    public static class EasyTypeDescriptor2InstanceExtension
    {
        public static InstanceUpFactory AsInstanceUpFactory(this EasyTypeDescriptor item)
        {
            var selectedItem = item;
            return (resolver, def) =>
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

                    var constructedImplType = implT;

                    if (implT.IsGenericParameter && !implT.IsConstructedGenericType)
                    {
                        // typeof(implT).MakeGenericType(type);
                        constructedImplType =  implT.MakeGenericType(def.GenericsDependencies);
                    }

                    var paras = constructedImplType
                        .ExportDependency(type => resolver.CanBeResolved(type))
                        .Select(type => resolver.GetInstance(type))
                        .ToArray();

                    return Activator.CreateInstance(implT, paras);
                }

                return null;
            };
        }
    }
}
