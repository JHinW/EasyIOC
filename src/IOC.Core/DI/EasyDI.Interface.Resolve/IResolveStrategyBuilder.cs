
namespace EasyDI.Definition.Resolve
{
    using EasyDI.Definition.Resolve.Abstractions;

    public interface IResolveStrategyBuilder
    {
        ResolveStrategyBase Build();

        void AddStrategyMiddleware(ResolvableMiddleware middleware);
    }
}
