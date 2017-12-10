

namespace EasyDI.Definition.Resolve
{
    public interface IGenericTree
    {
        IResolve Resolve { get; }

        bool IsConvertible { get; }

        IResolvable CreateResolvable();
    }
}
