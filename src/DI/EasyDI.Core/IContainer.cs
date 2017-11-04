using System;

namespace EasyDI.Core
{
    public interface IContainer
    {
        void AddDescriptor(Type key, EasyTypeDescriptor descriptor);

        EasyTypeDescriptorItem RemoveInstance(Type key);

        EasyTypeDescriptorItem this[Type index] { get; }

        IResolver CreateTypeResolver();

        ITracker CreateTracker();

        void Sync();
    }
}
