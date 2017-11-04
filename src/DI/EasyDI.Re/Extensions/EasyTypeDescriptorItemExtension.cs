using EasyDI.Core;
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
                return resolver =>
                {
                    return item
                    .ToArray()
                    .Select(disp => disp.AsInstanceFactory()(resolver));
                };
            }
            else
            {
                return selectedItem.AsInstanceFactory();
            }
            
        }
    }
}
