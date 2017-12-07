
namespace EasyDI.Interface.Resolve
{
    using EasyDI.Interface.Resolve.Abstractions;

    public interface IResolveStrategyBuilder
    {
        ResolveStrategyBase Build();
    }
}
