using EasyDI.Core;
using EasyDI.Re.Statics;
using System;
using System.Linq;
using static EasyDI.Core.Delegates;

namespace EasyDI.Re.Extensions
{
    public static class EasyTypeDescriptorItemExtension
    {
        public static InstanceFactory AsInstanceFactory(this EasyTypeDescriptorItem item, bool isArray)
        {
            var selectedItem = item.Last;
            if (isArray)
            {
                var realType = selectedItem.ServiceType;
                return resolver =>
                {
                    var rets =  item
                    .ToDispArray()
                    .Select(disp => disp.AsInstanceFactory()(resolver))
                    .ToArray();

                    return EnumrableHelper.CreateEnumrable(realType, rets);
                };
            }
            else
            {
                return selectedItem.AsInstanceFactory();
            }
        }
    }
}
