
namespace EasyDI.Container
{
    using EasyDI.Definition.Common;
    using EasyDI.Definition.Resolve;
    using static EasyDI.Definition.Container.Delegates;

    public delegate object ObjectDelegate(IProvider provider);

    public delegate InstanceFactoryResolverScope InstanceFactoryMiddleware(InstanceFactoryResolverScope instanceFactory);

    public delegate InstanceFactoryMiddleware InstanceFactoryResolvable(IResolvable resolvable);
}
