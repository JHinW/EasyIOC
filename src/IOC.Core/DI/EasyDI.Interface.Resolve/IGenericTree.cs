

namespace EasyDI.Interface.Resolve
{
    public interface IGenericTree
    {
        IResolve Resolve { get; }

        bool IsConvertible { get; }

        IResolvable CreateResolvable();
    }
}
