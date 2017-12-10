using EasyDI.Core;
using EasyDI.ReV2.Core;
using EasyDI.ReV2.Resolves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static EasyDI.ReV2.Delgates;

namespace EasyDI.ReV2.Extensions
{
    public static class EasyTypeDescriptorExtension
    {
        public static ResolvableFactory AsInstanceTrackScopeFactory(this EasyTypeDescriptor item, int index)
        {
            var selectedItem = item;


            ResolvableFactory factory = resolvable => tracker => (resolver, scope) =>
            {
                object ret = null;

                if (selectedItem.ImplementationFactory != null)
                {
                    ret = scope.TryAddOrUpdate(resolvable,
                       index,
                       item.Lifetime,
                       () => selectedItem.ImplementationFactory(resolver));
                }

                if (selectedItem.ImplementationInstance != null)
                {
                    ret = scope.TryAddOrUpdate(resolvable,
                       index,
                       item.Lifetime,
                       () => selectedItem.ImplementationInstance);
                }

                if (selectedItem.ImplementationType != null)
                {
                    ret = scope.TryAddOrUpdate(resolvable,
                       index,
                       item.Lifetime,
                       () =>
                       {
                           var implT = selectedItem.ImplementationType;

                           if (implT.IsGenericType
                           && !implT.IsConstructedGenericType)
                           {
                               // typeof(implT).MakeGenericType(type);
                               if(resolvable is GenericResolve)
                               {
                                   implT = implT.MakeGenericType(((GenericResolve)resolvable).DepTypes.ToArray());
                               }
                               
                           }

                           var paras = implT
                               .ExportConstructorParams(type => tracker.CanBeResolved(type))
                               .Select(type => resolver.GetInstance(type))
                               .ToArray();

                           return Activator.CreateInstance(implT, paras);

                       });
                }


                return ret;
            };

            return factory;
        }
    }


}
