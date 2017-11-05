using EasyDI.Re.Definitions;
using static EasyDI.Core.Delegates;

namespace EasyDI.Re.Extensions
{
    public static class ResolvableTypeDefExtension
    {
        public static InstanceFactory AsInstanceFactory(this ResolvableTypeDef def)
        {
            return resolver => {
                var factroy =  def.EasyTypeDescriptorItem.AsInstanceUpFactory();
                return factroy(resolver, def);
            };
        }
    }
}
