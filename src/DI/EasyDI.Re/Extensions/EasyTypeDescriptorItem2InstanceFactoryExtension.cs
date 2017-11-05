using EasyDI.Core;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using static EasyDI.Re.ReDelgates;
using EasyDI.Re.Statics;

namespace EasyDI.Re.Extensions
{
    public static class EasyTypeDescriptorItem2InstanceFactoryExtension
    {
        public static InstanceUpFactory AsInstanceUpFactory(this EasyTypeDescriptorItem item)
        {
            return (resolver, def) =>
            {
                if (def.OriginalType != def.ResolvableType
                && def.IsGenericType
                && def.IsEnumrableType)
                {
                    var rets = item
                    .ToDispArray()
                    .Select(disp => disp.AsInstanceUpFactory()(resolver, def))
                    .ToArray();
                    return EnumrableHelper.CreateEnumrable(def.ResolvableType, rets);
                }

                var factory = item.Last.AsInstanceUpFactory();
                return factory(resolver, def);
            };
        }
    }
}
